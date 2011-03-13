viewingByNameString
	"Answer a string to show in a menu representing whether the receiver is currently viewing its subparts by name or not"

	^ (self showingListView and: [(self valueOfProperty: #sortOrder ifAbsent: [nil]) == #downshiftedNameOfObjectRepresented])
		ifTrue:	['<yes>view by name']
		ifFalse:	['<no>view by name']
