//async and await 
async function A()
{
  console.log('I m async fnction')
  return Promise.resolve(1);
}
//A();
A().then(function(result){
 console.log(result);
});