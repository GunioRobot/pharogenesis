isPartsBinString
	^ self isPartsBin
		ifTrue:
			['stop being a parts bin']
		ifFalse:
			['start being a parts bin']
