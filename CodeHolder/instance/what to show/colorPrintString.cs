colorPrintString
	"Answer whether the receiver is showing colorPrint"

	^ (self showingColorPrint
		ifTrue: ['<yes>']
		ifFalse: ['<no>'])
		, 'colorPrint'