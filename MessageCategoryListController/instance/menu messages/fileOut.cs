fileOut
	"Print a description of the messages in the selected category onto an 
	external file."

	self controlTerminate.
	Cursor write showWhile:
		[model fileOutMessageCategories].
	self controlInitialize