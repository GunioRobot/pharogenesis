viewingNonOverlappingString
	"Answer a string to show in a menu representing whether the receiver is currently viewing its subparts by non-overlapping-icon (aka auto-line-layout)"

	^ (self showingListView or: [self autoLineLayout ~~ true])
		ifFalse:	['<yes>view with line layout']
		ifTrue:	['<no>view with line layout']
