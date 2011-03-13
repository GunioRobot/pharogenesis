browseVersionsOf: method class: class meta: meta
		category: category selector: selector 
	| changeList |
	Cursor read showWhile:
		[changeList _ self new
			scanVersionsOf: method class: class meta: meta
			category: category selector: selector].
	self openVersions: changeList name: 'Recent versions of ' , selector