<?php
    //save the lvl, name and score fields data with $_POST
    $lvl = $_POST['lvl'];
    $name = $_POST['name'];
    $minutes = $_POST['minutes'];
    $seconds = $_POST['seconds'];
    $fraction = $_POST['fraction'];
    
    //save the filename it should open depending on lvl;
    $fileName = "scoreslvl" . $lvl . ".txt";

    //opens the file to write
    $writeFile = fopen($fileName, "a");
    
    //writes score and name in file and goes to next line
    fwrite($writeFile, $minutes . $seconds . $fraction . "_" . $name . "\r\n");
    fclose($writeFile);

    //opens the file to read
    $readFile = fopen($fileName, "r");

    //save every line in the file in lines array
    $lines = explode("\r\n", fread($readFile, filesize($fileName)));
    sort($lines, 1);
    
    //$string = implode($lines)."\r\n";
    //echo($string);
    //echo every line
    foreach($lines as $line){
        echo($line);
        echo("\r\n");
    }
    
    fclose($readFile);
?>