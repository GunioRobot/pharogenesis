viewingByIconString
	"Answer a string to show in a menu representing whether the 
	receiver is currently viewing its subparts by icon or not"
	^ ((self showingListView
			or: [self autoLineLayout == true])
		ifTrue: ['<no>']
		ifFalse: ['<yes>']), 'view by icon' translated