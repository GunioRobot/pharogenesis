styleTable: anArray
	"Set the receiver's styleTable to anArray.
	Clear textAttributesByPixelSize cache so that it will reinitialize.	 
	" 
	
	styleTable := anArray.
	textAttributesByPixelHeight := nil