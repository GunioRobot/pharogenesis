drawOn: aCanvas 
	"Draw the background of the player"
	| box bgImage |
	box _ self bounds.
	bgImage _ self valueOfProperty: #transitionBackground ifAbsent:[nil].
	bgImage 
		ifNil:[aCanvas fillRectangle: box color: color]
		ifNotNil:[aCanvas drawImage: bgImage at: box origin].