splitterLeft

	| splitters |
	splitters _ ((self siblingSplitters select: [:each | each x < self x]) asSortedCollection: [:a :b | a x > b x]).
	
	^ splitters ifEmpty: nil ifNotEmpty: [splitters first]