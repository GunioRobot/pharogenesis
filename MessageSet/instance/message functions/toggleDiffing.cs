toggleDiffing
	"Differs from the inherited version in that it does not set contents to nil"

	self okToChange ifTrue:
		[self showDiffs: self showDiffs not.
		self changed: #contents]

