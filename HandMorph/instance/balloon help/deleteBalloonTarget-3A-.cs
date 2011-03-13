deleteBalloonTarget: aMorph
	"Delete the balloon help targeting the given morph"
	| h |
	h _ self balloonHelp ifNil:[^self].
	h balloonOwner == aMorph ifTrue:[self balloonHelp: nil].