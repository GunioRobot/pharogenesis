printOn: aStream level: level

	| keywords |
	receiver printOn: aStream level: level.
	arguments size = 0 ifTrue: [
		aStream space; nextPutAll: selector.
		^self
	].
	keywords _ selector keywords.
	1 to: keywords size do: [ :i |
		aStream space.
		aStream nextPutAll: (keywords at: i); space.
		(arguments at: i) printOn: aStream level: level + 1.
	].