browseVersionsOf: method class: class meta: meta
		category: category selector: selector lostMethodPointer: sourcePointer
	| changeList |
	Cursor read showWhile:
		[changeList _ self new
			scanVersionsOf: method class: class meta: meta
			category: category selector: selector].
	changeList setLostMethodPointer: sourcePointer.
	self openVersions: changeList name: 'Recent versions of ' , selector