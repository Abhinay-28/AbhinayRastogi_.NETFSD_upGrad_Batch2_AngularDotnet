
let marks = 68;
let grade;

if (marks >= 75) {
    grade = "Grade A";
} 
else if (marks >= 60) {
    grade = "Grade B";
} 
else if (marks >= 40) {
    grade = "Grade C";
} 
else {
    grade = "Fail";
}

document.write("Marks: " + marks + "<br>");
document.write("Result: " + grade);

console.log("Marks:", marks);
console.log("Grade:", grade);
