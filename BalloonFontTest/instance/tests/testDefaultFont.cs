testDefaultFont
	"(self selector: #testDefaultFont) debug"
	self assert: RectangleMorph new balloonFont = BalloonMorph balloonFont.
	self assert: RectangleMorph new defaultBalloonFont = BalloonMorph balloonFont.