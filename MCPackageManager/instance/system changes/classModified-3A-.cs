classModified: anEvent
	(self packageInfo includesClass: anEvent item) ifTrue: [self modified: true]