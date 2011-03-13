characterFormAt: character 
	"Answer a Form copied out of the glyphs for the argument, character."
	| ascii leftX rightX characterForm |
	ascii _ character asciiValue.
	leftX _ xTable at: ascii + 1.
	rightX _ xTable at: ascii + 2.
	characterForm _ Form extent: (rightX-leftX) @ self height.
	characterForm copy: characterForm boundingBox
		from: leftX@0 in: glyphs rule: Form over.
	^ characterForm