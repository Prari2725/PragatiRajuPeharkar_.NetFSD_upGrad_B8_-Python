//promise
let promise=new Promise(function(resolve,reject)
{
  setTimeout(function()
  {
    resolve('promise rejectd')},3000);
  });
  let promise2;
  //async function
  async function name1() {
    let result= await promise;
    let result2=await promise2;
    console.log(result);
    console.log(result2);
    
  }
  name1();