buttonOnColor
	
	| val |
	^ (val _ self valueOfProperty: #buttonOnColor)
		ifNotNil:
			[val]
		ifNil:
			[Color yellow]