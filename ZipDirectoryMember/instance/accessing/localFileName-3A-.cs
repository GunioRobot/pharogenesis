localFileName: aString
	| dir entry parent |
	super localFileName: aString.
	fileName last = $/ ifFalse: [ fileName _ fileName, '/' ].
	parent _ FileDirectory default.
	(parent directoryExists: fileName) ifTrue: [
		dir _ FileDirectory on: (parent fullNameFor: fileName).
		entry _ dir directoryEntry.
		self setLastModFileDateTimeFrom: entry modificationTime
	]
