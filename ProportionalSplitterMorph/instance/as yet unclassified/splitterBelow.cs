splitterBelow

	| splitters |
	splitters _ ((self siblingSplitters select: [:each | each y < self y]) asSortedCollection: [:a :b | a y > b y]).
	
	^ splitters ifEmpty: nil ifNotEmpty: [splitters first]