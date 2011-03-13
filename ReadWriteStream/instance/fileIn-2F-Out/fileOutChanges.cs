fileOutChanges
	"Append to the receiver a description of all class changes."
	Cursor write showWhile:
		[self header; timeStamp.
		Smalltalk changes fileOutOn: self.
		self trailer; close]