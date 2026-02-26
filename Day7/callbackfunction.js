//function
function print(name,function1)
{
  console.log("hi how are you")
  function1(name);
}
//callback function
function call(name)
{
  console.log('hello' +'' +name);
}
setTimeout(print,2000,'pragati',call);
//print('pragati');