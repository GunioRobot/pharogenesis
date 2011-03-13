showBalloon: msgString
	"Pop up a balloon containing the given string, first removing any existing BalloonMorphs in the world."

	| w balloon |
	w _ self world.
	w ifNil: [^ self].
	balloon _ BalloonMorph string: msgString for: self corner: #bottomRight.
	w submorphsDo: [:m |  "delete any existing balloons"
		(m isKindOf: BalloonMorph) ifTrue: [m delete]].
	w addMorphFront: balloon.
	self setProperty: #balloon toValue: balloon.
