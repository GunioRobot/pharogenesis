classMoved: anEvent
	((self packageInfo includesSystemCategory: anEvent oldCategory)
		or: [self packageInfo includesClass: anEvent item])
			ifTrue: [self modified: true]