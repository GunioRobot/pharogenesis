mouseLeave: evt
	| hand tile |
	owner ifNil: [^ self].	"left by being removed, not by mouse movement"
	self stopStepping.
	handWithTile _ nil.
	self removeSpaces.
	hand _ evt hand.
	(hand submorphs size = 1) & (hand lastEvent redButtonPressed) ifTrue:
		[tile _ hand firstSubmorph.
		(tile isKindOf: PhraseTileMorph) ifTrue: [tile unbrightenTiles]].
