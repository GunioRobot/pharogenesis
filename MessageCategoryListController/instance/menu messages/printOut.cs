printOut
	"Make a file with the description of the selected mesage category in Html format."

	self controlTerminate.
	Cursor write showWhile:
		[model printOutMessageCategories].
	self controlInitialize