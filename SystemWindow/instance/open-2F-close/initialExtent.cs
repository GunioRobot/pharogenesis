initialExtent
	^ Preferences bigDisplay
		ifTrue: [(model initialExtent * 1.75) rounded]
		ifFalse: [model initialExtent]