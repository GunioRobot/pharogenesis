showBalloon
	"If this Morph has balloon text, create a balloon and add it."
	| str balloon |
	(str _ self balloonText) ifNil: [^ self].
	balloon _ BalloonMorph string: str for: self corner: #topRight.
	"corner is a suggestion"
	self world addMorphFront: balloon.
	self setProperty: #balloon toValue: balloon