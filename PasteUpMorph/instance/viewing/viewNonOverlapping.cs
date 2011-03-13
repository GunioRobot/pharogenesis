viewNonOverlapping
	"Make the receiver show its contents as full-size morphs laid out left-to-right and top-to-bottom to be non-overlapping."

	self viewingNormally ifTrue:
		[self saveBoundsOfSubmorphs].
	self showingListView ifTrue:
		[self viewByIcon.
		self removeProperty: #showingListView].
	self autoLineLayout: true.