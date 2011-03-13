showBalloon: msgString hand: aHand
	"Pop up a balloon containing the given string,
	first removing any existing BalloonMorphs in the world."

	| w balloon h |
	(w _ self world) ifNil: [^ self].
	h _ aHand.
	h ifNil:[
		h _ w activeHand].
	balloon _ BalloonMorph string: msgString for: self balloonHelpAligner.
	balloon popUpFor: self hand: h.