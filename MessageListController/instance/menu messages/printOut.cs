printOut
	"Write a description of the selected message on an external file."
	self controlTerminate.
	Cursor write showWhile:
		[model printOutMessage].
	self controlInitialize