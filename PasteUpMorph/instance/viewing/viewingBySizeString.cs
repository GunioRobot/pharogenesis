viewingBySizeString
	"Answer a string to show in a menu representing whether the 
	receiver is currently viewing its subparts by size or not"
	^ ((self showingListView
			and: [(self
					valueOfProperty: #sortOrder
					ifAbsent: [])
					== #reportableSize])
		ifTrue: ['<yes>']
		ifFalse: ['<no>']), 'view by size' translated