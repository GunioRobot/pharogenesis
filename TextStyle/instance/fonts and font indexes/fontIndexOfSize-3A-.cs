fontIndexOfSize: desiredHeight
	"Returns an index in fontArray of the font with height <= desiredHeight"
	"Leading is not inluded in the comparison"
	| bestMatch bestIndex d |
	bestMatch _ 9999.  bestIndex _ 1.
	1 to: fontArray size do:
		[:i | d _ desiredHeight - (fontArray at: i) height.
		d = 0 ifTrue: [^ i].
		(d > 0 and: [d < bestMatch]) ifTrue: [bestIndex _ i. bestMatch _ d]].
	^ bestIndex