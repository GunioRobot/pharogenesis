positionObject: anObject
	"anObject could be myself or my referent"

	| container |
	(container _ self currentWorld viewBox) ifNil: [^ self].
	"Could consider container _ referent pasteUpMorph, to allow flaps on things other than the world, but for the moment, let's skip it!"
	(edgeToAdhereTo == #left) ifTrue:
		[^ anObject left: container left].
	(edgeToAdhereTo == #right) ifTrue:
		[^ anObject right: container right].
	(edgeToAdhereTo == #top) ifTrue:
		[^ anObject top: container top].
	(edgeToAdhereTo == #bottom) ifTrue:
		[^ anObject bottom: container bottom]