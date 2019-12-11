<?php

$connect=mysql_connect("localhost","root","") or die(" dbconntion error"); 
mysql_select_db("hopstick2019");
if(!$connect) $connect=dbConn();  

$sql="SELECT *FROM  userinfo";
$result=mysql_query($sql,  $connect);
if ($result)
{
 while($row=mysql_fetch_array($result))
 {
  $flag[]=$row;
 }
 print(json_encode($flag));
}
mysql_close($connect);
?>