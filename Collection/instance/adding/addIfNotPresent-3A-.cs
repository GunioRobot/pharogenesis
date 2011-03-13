addIfNotPresent: anObject

	(self includes: anObject) ifFalse: [^ self add: anObject]