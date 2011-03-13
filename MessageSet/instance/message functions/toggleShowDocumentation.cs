toggleShowDocumentation
	"Toggle the setting of the showDocumentation flag"

	self okToChange ifTrue:
		[self showDocumentation: self showingDocumentation not.
		self changed: #contents]

