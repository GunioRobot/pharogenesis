printOut
	"Print a description of the selected class onto an external file in HTML format."

	self controlTerminate.
	Cursor write showWhile:
		[model printOutClass].
	self controlInitialize