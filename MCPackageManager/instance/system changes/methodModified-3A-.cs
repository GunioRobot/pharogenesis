methodModified: anEvent
	(self packageInfo includesMethod: anEvent itemSelector ofClass: anEvent itemClass)
		ifTrue: [self modified: true]