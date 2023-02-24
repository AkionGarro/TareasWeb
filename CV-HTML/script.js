function getRealTime() {
  let time = new Date();
  return time.toLocaleString();
}

function updateTime() {
  let timeElement = document.getElementById("time");
  timeElement.innerHTML = getRealTime();
}

setInterval(updateTime, 1000);

function changeFonts() {
  let body = document.querySelector("body");
  if (body.style.fontFamily === "Arial, sans-serif") {
    body.style.fontFamily = "Times New Roman, serif";
  } else {
    body.style.fontFamily = "Arial, sans-serif";
  }
}
