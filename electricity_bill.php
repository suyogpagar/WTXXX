<!DOCTYPE html>
<html>
<head>
    <title>Electricity Bill Calculator</title>
</head>
<body>
    <h2>Electricity Bill Calculator</h2>
    <form method="POST">
        <label>Enter Units Consumed:</label>
        <input type="number" name="units" required>
        <button type="submit">Calculate</button>
    </form>

    <?php
    function calculateBill($units) {
        $bill = 0;

        if ($units <= 50) {
            $bill = $units * 3.50;
        } elseif ($units <= 150) {
            $bill = (50 * 3.50) + (($units - 50) * 4.00);
        } elseif ($units <= 250) {
            $bill = (50 * 3.50) + (100 * 4.00) + (($units - 150) * 5.20);
        } else {
            $bill = (50 * 3.50) + (100 * 4.00) + (100 * 5.20) + (($units - 250) * 6.50);
        }

        return round($bill, 2);
    }

    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $units = $_POST["units"];

        if ($units < 0) {
            echo "<p>Please enter a valid positive number.</p>";
        } else {
            $total = calculateBill($units);
            echo "<p>Units Consumed: <strong>$units</strong></p>";
            echo "<p>Total Electricity Bill: <strong>₹$total</strong></p>";
        }
    }
    ?>
</body>
</html>
