methodMoved: anEvent 
	((self packageInfo includesMethod: anEvent itemSelector ofClass: anEvent itemClass)
		or: [(self packageInfo 
					includesMethodCategory: anEvent oldCategory 
					ofClass: anEvent itemClass)
				or: [self packageInfo 
							includesMethodCategory: anEvent itemCategory 
							ofClass: anEvent itemClass]])
		ifTrue: [self modified: true]