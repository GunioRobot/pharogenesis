positionObject: anObject
        "anObject could be myself or my referent"

"Could consider container := referent pasteUpMorph, to allow flaps on things other than the world, but for the moment, let's skip it!"

	"19 sept 2000 - going for all paste ups"

	| pum |
	pum := self pasteUpMorph ifNil: [^ self].

	^self 
		positionObject: anObject 
		atEdgeOf: pum clearArea