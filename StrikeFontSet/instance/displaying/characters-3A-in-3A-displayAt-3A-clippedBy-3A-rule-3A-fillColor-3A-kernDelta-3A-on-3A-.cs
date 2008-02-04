characters: anInterval in: sourceString displayAt: aPoint clippedBy: clippingRectangle rule: ruleInteger fillColor: aForm kernDelta: kernDelta on: aBitBlt
	"Simple, slow, primitive method for displaying a line of characters.
	No wrap-around is provided."

	| ascii encoding destPoint leftX rightX sourceRect xTable noFont f |
	destPoint := aPoint.
	anInterval do: 
		[:i |
		encoding := (sourceString at: i) leadingChar + 1.
		noFont := false.
		[f := fontArray at: encoding]
			on: Exception do: [:ex | noFont := true. f := fontArray at: 1].
		f ifNil: [noFont := true. f := fontArray at: 1].
		ascii := noFont ifTrue: [$?] ifFalse: [(sourceString at: i) charCode].
		(ascii < f minAscii
			or: [ascii > f maxAscii])
			ifTrue: [ascii := f maxAscii].
		xTable := f xTable.
		leftX := xTable at: ascii + 1.
		rightX := xTable at: ascii + 2.
		sourceRect := leftX@0 extent: (rightX-leftX) @ self height.
		aBitBlt copyFrom: sourceRect in: f glyphs to: destPoint.
		destPoint := destPoint + ((rightX-leftX+kernDelta)@0).
		"destPoint printString displayAt: 0@(i*20)."
	].
	^ destPoint.
