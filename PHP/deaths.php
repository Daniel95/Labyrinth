<?php
    //opens the file to read
    $readFile = fopen("totaldeaths.txt", "r") or die("Unable to open file!");

    //save value of totaldeaths.txt in $deaths
    $deaths = fread($readFile, filesize("totaldeaths.txt"));
    
    //outputs $deaths
    echo($deaths + 1);

    fclose($readFile);
    
    
    //opens the file to write
    $writeFile = fopen("totaldeaths.txt", "w+");

    //write new $deaths value in totaldeaths.txt
    fwrite($writeFile, $deaths + 1);

    fclose($writeFile);
?>