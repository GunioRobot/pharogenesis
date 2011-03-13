browseVersionsOf: method class: class meta: meta
		category: category selector: selector 
	| changeList |
	Cursor read showWhile:
		[changeList _ self new
			scanVersionsOf: method class: class meta: meta
			category: category selector: selector].
	changeList ifNotNil:
		[self open: changeList name: 'Recent versions of ' , selector multiSelect: false]