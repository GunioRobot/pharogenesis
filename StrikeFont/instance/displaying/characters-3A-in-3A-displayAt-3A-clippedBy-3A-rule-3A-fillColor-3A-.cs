characters: anInterval in: sourceString displayAt: aPoint 
	clippedBy: clippingRectangle rule: ruleInteger fillColor: aForm 	"Simple, slow, primitive method for displaying a line of characters.
	No wrap-around is provided."
	| ascii destPoint bb leftX rightX sourceRect |
	destPoint _ aPoint.
	bb _ BitBlt current toForm: Display.
	anInterval do: 
		[:i | 
		ascii _ (sourceString at: i) asciiValue.
		(ascii < minAscii or: [ascii > maxAscii])
			ifTrue: [ascii _ maxAscii].
		leftX _ xTable at: ascii + 1.
		rightX _ xTable at: ascii + 2.
		sourceRect _ leftX@0 extent: (rightX-leftX) @ self height.
		bb copyFrom: sourceRect in: glyphs to: destPoint.
		destPoint _ destPoint + ((rightX-leftX)@0)].
	^ destPoint