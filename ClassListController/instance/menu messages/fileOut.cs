fileOut
	"Print a description of the selected class onto an external file in .st format."

	self controlTerminate.
	Cursor write showWhile:
		[model fileOutClass].
	self controlInitialize