buttonOffColor
	
	| val |
	^ (val _ self valueOfProperty: #buttonOffColor)
		ifNotNil:
			[val]
		ifNil:
			[Color r: 0.4 g: 0.2 b: 0.6]