characters: anInterval in: sourceString displayAt: aPoint clippedBy: clippingRectangle rule: ruleInteger fillColor: aForm kernDelta: kernDelta on: aBitBlt
	"Simple, slow, primitive method for displaying a line of characters.
	No wrap-around is provided."
	| ascii destPoint leftX rightX sourceRect |
	destPoint _ aPoint.
	anInterval do: 
		[:i |
		self flag: #yoDisplay.
		"if the char is not supported, fall back to the specified fontset."
		ascii _ (sourceString at: i) charCode.
		(ascii < minAscii or: [ascii > maxAscii])
			ifTrue: [ascii _ maxAscii].
		leftX _ xTable at: ascii + 1.
		rightX _ xTable at: ascii + 2.
		sourceRect _ leftX@0 extent: (rightX-leftX) @ self height.
		aBitBlt copyFrom: sourceRect in: glyphs to: destPoint.
		destPoint _ destPoint + ((rightX-leftX+kernDelta)@0).
		"destPoint printString displayAt: 0@(i*20)"].
	^ destPoint