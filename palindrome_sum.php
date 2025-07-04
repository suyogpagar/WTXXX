<!DOCTYPE html>
<html>
<head>
    <title>Palindrome & Digit Sum Checker</title>
</head>
<body>
    <h2>Enter a Number</h2>
    <form method="POST">
        <input type="text" name="number" required>
        <button type="submit">Check</button>
    </form>

    <?php
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $num = $_POST['number'];

        if (!ctype_digit($num)) {
            echo "<p>Please enter a valid positive integer.</p>";
        } else {
            $reversed = strrev($num);
            $isPalindrome = ($num == $reversed);
            $sum = array_sum(str_split($num));

            echo "<p>Entered Number: <strong>$num</strong></p>";
            echo "<p>Palindrome: <strong>" . ($isPalindrome ? "Yes" : "No") . "</strong></p>";
            echo "<p>Sum of Digits: <strong>$sum</strong></p>";
        }
    }
    ?>
</body>
</html>
