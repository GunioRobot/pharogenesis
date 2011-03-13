closestPixelWord2
	"Return the nearest approximation to this color for a 2-bit deep Form."

	| b |
	self = PureYellow ifTrue: [ ^ 16rFFFFFFFF ].	"16 pixels by 2 bits each"
	b _ self brightness.
	b >= 0.75 ifTrue: [ ^ 0 ].
	b <= 0.25 ifTrue: [ ^ 16r55555555 ].
	^ 16rAAAAAAAA