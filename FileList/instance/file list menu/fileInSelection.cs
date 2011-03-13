fileInSelection
	"FileIn all of the selected file."
	self canDiscardEdits ifFalse: [^ self changed: #flash].
	self fileAllIn.
