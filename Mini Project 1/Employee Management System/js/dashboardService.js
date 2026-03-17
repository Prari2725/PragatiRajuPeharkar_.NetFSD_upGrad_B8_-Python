(function (global) {
  const employeeService = global.employeeService || require('./employeeService');

  const dashboardService = {
    /** Computes high-level dashboard summary. */
    getSummary() {
      const employees = employeeService.getAll();
      const uniqueDepartments = new Set(employees.map((employee) => employee.department));
      return {
        total: employees.length,
        active: employees.filter((employee) => employee.status === 'Active').length,
        inactive: employees.filter((employee) => employee.status === 'Inactive').length,
        departments: uniqueDepartments.size
      };
    },
    /** Returns per-department employee counts. */
    getDepartmentBreakdown() {
      const employees = employeeService.getAll();
      const total = employees.length || 1;
      const counts = employees.reduce((accumulator, employee) => {
        accumulator[employee.department] = (accumulator[employee.department] || 0) + 1;
        return accumulator;
      }, {});

      return Object.entries(counts).map(([department, count]) => ({
        department,
        count,
        percentage: Math.round((count / total) * 100)
      }));
    },
    /** Returns the latest n employees by id. */
    getRecentEmployees(n) {
      return employeeService
        .sortBy('id', 'desc', employeeService.getAll())
        .slice(0, n);
    }
  };

  global.dashboardService = dashboardService;
  if (typeof module !== 'undefined' && module.exports) {
    module.exports = dashboardService;
  }
})(typeof globalThis !== 'undefined' ? globalThis : window);
