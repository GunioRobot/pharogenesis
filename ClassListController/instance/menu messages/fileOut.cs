fileOut
	"Print a description of the selected class onto an external file."

	self controlTerminate.
	Cursor write showWhile:
		[model fileOutClass].
	self controlInitialize