get
	"Get contents of file again, it may have changed. Do this by making the 
	cancel string be the contents, and doing a cancel."

	Cursor read
		showWhile: 
			[initialText _ (model readContentsBrief: false) asText.
			self cancel]