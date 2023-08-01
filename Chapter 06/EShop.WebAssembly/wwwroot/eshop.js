function download() {
  const current = new Date();
  const day = current.getDate()
  const month = current.getMonth() + 1
  const year = current.getFullYear()
  const time = year + "/" + month + "/" + day + " " + current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
  const data = 'hello world!' + "\n" + time;
  const blob = new Blob([data]);
  const url = URL.createObjectURL(blob);
  const anchorElement = document.createElement('a');
  anchorElement.href = url;
  anchorElement.download = 'hello.txt';
  anchorElement.click();
  anchorElement.remove();
  URL.revokeObjectURL(url);
}