toggleDiffing
	"Toggle whether diffs should be shown in the code pane"

	self okToChange ifTrue:
		[self showDiffs: self showDiffs not.
		self changed: #contents.
		self update]

