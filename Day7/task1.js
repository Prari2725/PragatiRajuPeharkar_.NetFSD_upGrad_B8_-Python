function markscalculator(){
let marks=[32,78,56,45,98,49,67];

const total=marks.reduce((a,b)=>a+b,0) ;

const avg=total/marks.length;

const rst = avg >= 35 ? "Pass" : "Fail";


console.log(`total marks is ${total}`);
console.log(`Average is ${avg}`);
console.log(`your result status is ${rst}`);

const studentData = {
    Marks: marks.join(", "),
    Total: total,
    Average: avg,
    Result: rst
};
console.table(studentData);
}


markscalculator();





