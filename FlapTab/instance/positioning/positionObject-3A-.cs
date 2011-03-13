positionObject: anObject
        "anObject could be myself or my referent"

"Could consider container _ referent pasteUpMorph, to allow flaps on things other than the world, but for the moment, let's skip it!"

	"19 sept 2000 - going for all paste ups"

	^self 
		positionObject: anObject 
		atEdgeOf: (self pasteUpMorph ifNil: [^ self])