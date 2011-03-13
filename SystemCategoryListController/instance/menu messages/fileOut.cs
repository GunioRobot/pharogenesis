fileOut
	"Print a description of the classes in the selected system category onto an 
	external file."

	self controlTerminate.
	Cursor write showWhile:
		[model fileOutSystemCategories].
	self controlInitialize