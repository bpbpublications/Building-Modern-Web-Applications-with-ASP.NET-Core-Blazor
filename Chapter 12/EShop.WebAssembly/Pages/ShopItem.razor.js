export function download(name) {
  const current = new Date();
  const day = current.getDate()
  const month = current.getMonth() + 1
  const year = current.getFullYear()
  const time = year + "/" + month + "/" + day + " " + current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
  const data = 'hello, ' + name + '!' + "\n" + time;
  const blob = new Blob([data]);
  const url = URL.createObjectURL(blob);
  const anchorElement = document.createElement('a');
  anchorElement.href = url;
  anchorElement.download = 'hello.txt';
  anchorElement.click();
  anchorElement.remove();
  URL.revokeObjectURL(url);

  var status = {
    succeed: true,
    name: name,
    time: current,
  };

  return status;
}

function getProject(key) {
  DotNet.invokeMethodAsync('EShop.WebAssembly', 'getProj', key)
    .then(data => {
      console.log(data);
    });
}

getProject('Description');