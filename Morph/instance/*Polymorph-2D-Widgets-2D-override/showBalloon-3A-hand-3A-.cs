showBalloon: msgString hand: aHand
	"Pop up a balloon containing the given string,
	first removing any existing BalloonMorphs in the world."

	|w h|
	(w := self world) ifNil: [^self].
	h := aHand ifNil: [w activeHand].
	(UITheme builder newBalloonHelp: msgString for: self balloonHelpAligner)
		popUpFor: self hand: h