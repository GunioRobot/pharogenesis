toggleDiff
	self okToChange ifTrue:
		[self showDiffs: self showDiffs not.
		contents _ nil.
		self changed: #contents]

