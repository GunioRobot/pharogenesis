initialize  
	"Clear styleTable and textAttributesByPixelSize cache so that they will 
	reinitialize.	 

		SHTextStylerST80 initialize
	" 
	
	styleTable := nil.
	textAttributesByPixelHeight := nil.	
	self initializePreferences