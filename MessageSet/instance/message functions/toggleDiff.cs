toggleDiff
	self okToChange ifTrue:
		[self showDiffs: self showDiffs not.
		self changed: #contents]

