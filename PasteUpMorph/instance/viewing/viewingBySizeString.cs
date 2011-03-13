viewingBySizeString
	"Answer a string to show in a menu representing whether the receiver is currently viewing its subparts by size or not"

	^ (self showingListView and: [(self valueOfProperty: #sortOrder ifAbsent: [nil]) == #reportableSize])
		ifTrue:	['<yes>view by size']
		ifFalse:	['<no>view by size']
