showBalloon: msgString
	"Pop up a balloon containing the given string,
	first removing any existing BalloonMorphs in the world."
	| w |
	self showBalloon: msgString hand: ((w _ self world) ifNotNil:[w activeHand]).