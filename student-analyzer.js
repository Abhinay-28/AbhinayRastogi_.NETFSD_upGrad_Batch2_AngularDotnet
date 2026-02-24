const marks = [72, 65, 80, 55, 90];

const calculateTotal = arr =>
    arr.reduce((sum, mark) => sum + mark, 0);

const calculateAverage = arr =>
    calculateTotal(arr) / arr.length;

const formattedMarks = marks.map(mark => `Mark: ${mark}`);

const total = calculateTotal(marks);
const average = calculateAverage(marks);

const result = average >= 40 ? "Pass" : "Fail";

document.getElementById("output").innerHTML = `
<p>${formattedMarks.join("<br>")}</p>
<p>Total Marks: ${total}</p>
<p>Average Marks: ${average.toFixed(2)}</p>
<p>Result: ${result}</p>
`;