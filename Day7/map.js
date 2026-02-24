

let arr =[10,20,30,40,50];
let m = new Map();
for(let i=0;i<arr.length;i++){
    m.set(i,arr[i]);
}
console.log(m.delete(3));

