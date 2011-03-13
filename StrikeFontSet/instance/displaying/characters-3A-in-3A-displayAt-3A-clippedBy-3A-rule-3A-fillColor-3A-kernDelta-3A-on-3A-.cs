characters: anInterval in: sourceString displayAt: aPoint clippedBy: clippingRectangle rule: ruleInteger fillColor: aForm kernDelta: kernDelta on: aBitBlt
	"Simple, slow, primitive method for displaying a line of characters.
	No wrap-around is provided."

	| ascii encoding destPoint leftX rightX sourceRect xTable noFont f |
	destPoint _ aPoint.
	anInterval do: 
		[:i |
		encoding _ (sourceString at: i) leadingChar + 1.
		noFont _ false.
		[f _ fontArray at: encoding]
			on: Exception do: [:ex | noFont _ true. f _ fontArray at: 1].
		f ifNil: [noFont _ true. f _ fontArray at: 1].
		ascii _ noFont ifTrue: [$?] ifFalse: [(sourceString at: i) charCode].
		(ascii < f minAscii
			or: [ascii > f maxAscii])
			ifTrue: [ascii _ f maxAscii].
		xTable _ f xTable.
		leftX _ xTable at: ascii + 1.
		rightX _ xTable at: ascii + 2.
		sourceRect _ leftX@0 extent: (rightX-leftX) @ self height.
		aBitBlt copyFrom: sourceRect in: f glyphs to: destPoint.
		destPoint _ destPoint + ((rightX-leftX+kernDelta)@0).
		"destPoint printString displayAt: 0@(i*20)."
	].
	^ destPoint.
