(function (global) {
  const employeeService = global.employeeService || require('./employeeService');
  const storageService = global.storageService || require('./storageService');

  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const phonePattern = /^\d{10}$/;
  const datePattern = /^\d{4}-\d{2}-\d{2}$/;

  const validationService = {
    /** Validates auth forms for signup or login. */
    validateAuthForm(formData, type) {
      const errors = {};
      const username = String(formData.username || '').trim();
      const password = String(formData.password || '');
      const confirmPassword = String(formData.confirmPassword || '');

      if (!username) {
        errors.username = 'Username is required.';
      }
      if (!password) {
        errors.password = 'Password is required.';
      }

      if (type === 'signup') {
        if (!confirmPassword) {
          errors.confirmPassword = 'Please confirm your password.';
        }
        if (password && password.length < 6) {
          errors.password = 'Password must be at least 6 characters.';
        }
        if (password && confirmPassword && password !== confirmPassword) {
          errors.confirmPassword = 'Password and Confirm Password must match exactly.';
        }
        if (username && storageService.findAdminByUsername(username)) {
          errors.username = 'Username already exists. Please choose another one.';
        }
      }

      return errors;
    },
    /** Validates employee add/edit form fields. */
    validateEmployeeForm(formData) {
      const errors = {};
      const requiredFields = ['firstName', 'lastName', 'email', 'phone', 'department', 'designation', 'salary', 'joinDate', 'status'];

      requiredFields.forEach((field) => {
        if (!String(formData[field] ?? '').trim()) {
          errors[field] = 'This field is required.';
        }
      });

      if (!errors.email && !emailPattern.test(String(formData.email).trim())) {
        errors.email = 'Enter a valid email address.';
      }
      if (!errors.phone && !phonePattern.test(String(formData.phone).trim())) {
        errors.phone = 'Phone number must contain exactly 10 digits.';
      }
      if (!errors.salary && (!Number.isFinite(Number(formData.salary)) || Number(formData.salary) <= 0)) {
        errors.salary = 'Salary must be a positive number.';
      }
      if (!errors.joinDate && !datePattern.test(String(formData.joinDate).trim())) {
        errors.joinDate = 'Join date must be in YYYY-MM-DD format.';
      }
      if (!errors.email && employeeService.emailExists(formData.email, formData.id)) {
        errors.email = 'Email already exists for another employee.';
      }

      return errors;
    }
  };

  global.validationService = validationService;
  if (typeof module !== 'undefined' && module.exports) {
    module.exports = validationService;
  }
})(typeof globalThis !== 'undefined' ? globalThis : window);
