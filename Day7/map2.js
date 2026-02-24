
// let arr1=[10,20,20,30,30,40,50,50]
// let s=new Set()
// for(let i=0;i<arr1.length;i++){
//     s.add(arr1[i])
// }
// console.log(s)

let arr2=[10,20,20,30,30,40,50,50]
let unique = [];

arr2.forEach((arr2) => {
    if (!unique.includes(arr2)) {
        unique.push(arr2);
    }
});

console.log(unique);

//

// let arr3 = [10,20,20,30,30,40,50,50];

// let unique = [...new Set(arr)];

// console.log(unique);