currentColor

	^ current = 1 ifTrue: [Color transparent]
		ifFalse: [Color indexedColors at: current]