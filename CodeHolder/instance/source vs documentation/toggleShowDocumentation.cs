toggleShowDocumentation
	"Toggle the setting of the showingDocumentation flag, unless there are unsubmitted edits that the user declines to discard"

	self okToChange ifTrue:
		[self showDocumentation: self showingDocumentation not.
		contents _ nil.
		self changed: #contents]

