testSpecificFont
	"(self selector: #testSpecificFont) debug"
	| aMorph |
	aMorph := RectangleMorph new.
	self assert: RectangleMorph new balloonFont = BalloonMorph balloonFont.
	self assert: RectangleMorph new defaultBalloonFont = BalloonMorph balloonFont.
	aMorph
		balloonFont: (StrikeFont familyName: #ComicPlain size: 19).
	self assert: aMorph balloonFont
			= (StrikeFont familyName: #ComicPlain size: 19).
	"The next test is horrible because I do no know how to access the font 
	with the appropiate interface"
	self assert: (((BalloonMorph getTextMorph: 'lulu' for: aMorph) text runs at: 1)
			at: 1) font
			= (StrikeFont familyName: #ComicPlain size: 19)