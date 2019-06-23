# SerialCommandCentre

How the program works:

Serial port:  
  For the program to work it needs string in the format   
  
  Keyword:Data|keyword2:Data|keyword3:Data
  
  The string is split at | . It then takes the keyword and places it in the correct keyword dictionary and a list with the same
  keyword. To call the dictionary use home1.dataDictionary with a keyword(Eg Gas). Same goes with the lists, just use home.gasPara 
  or any other list. The other lists can be found in Home.cs.
  
  It's important to note that the only keywords the program reads "//time" , "temp" , "press" , "latitude" , "longitude" , 
  "altitude" , "humidity" , "gas" , "UVA" , "UVB" , "UVI" and "acc". If you want to change this you need to edit the program 
  yourself. 
  
  

  
