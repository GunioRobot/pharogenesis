drawTitle: aCanvas 
	"Draw the text inside"
	| newBound text |
	newBound _ Rectangle center: self bounds center + (3 @ 0) extent: 12 @ 12.
	text _ self getText.
	aCanvas
		text: text
		bounds: newBound
		font: nil
		color: Color white.
aCanvas
		text: text
		bounds: (newBound translateBy: -1)
		font: nil
		color: (self defaultColor alphaMixed: 0.7 with: Color black)