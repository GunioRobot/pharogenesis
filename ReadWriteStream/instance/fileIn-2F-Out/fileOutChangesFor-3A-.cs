fileOutChangesFor: class
	"Append to the receiver a description of the changes to the class."
	Cursor write showWhile:
		[self header; timeStamp.
		Smalltalk changes fileOutChangesFor: class on: self;
			fileOutPSFor: class on: self.
		(class inheritsFrom: Class)
			ifFalse: [Smalltalk changes fileOutChangesFor: class class on: self;
						fileOutPSFor: class class on: self].
		self trailer; close]