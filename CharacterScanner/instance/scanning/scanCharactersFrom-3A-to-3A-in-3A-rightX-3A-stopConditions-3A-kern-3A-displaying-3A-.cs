scanCharactersFrom: startIndex to: stopIndex in: sourceString rightX: rightX stopConditions: stops kern: kernDelta displaying: display 
	"This method will perform text scanning with non-zero kerning.
	It calls the faster primitive method, if the kern delta is zero.
	Some day we may want to put kerning into the primitive."
	| ascii nextDestX maxAscii fillBlt |
	kernDelta = 0 ifTrue:
		[^ self scanCharactersFrom: startIndex to: stopIndex in: sourceString
				rightX: rightX stopConditions: stops displaying: display].
	display ifTrue: [fillBlt _ self fillBlt].
	maxAscii _ xTable size-2.
	lastIndex _ startIndex.
	[lastIndex <= stopIndex]
		whileTrue: 
			[ascii _ (sourceString at: lastIndex) asciiValue.
			ascii > maxAscii ifTrue: [ascii _ maxAscii].
			(stopConditions at: ascii + 1) == nil
				ifFalse: [^stops at: ascii + 1].
			sourceX _ xTable at: ascii + 1.
			nextDestX _ destX + (width _ (xTable at: ascii + 2) - sourceX).
			nextDestX > rightX ifTrue: [^stops at: CrossedX].
			display ifTrue:
				[self copyBits
				fillBlt == nil ifFalse:
					[fillBlt destX: nextDestX destY: destY
							width: kernDelta height: height;
							copyBits]].
			destX _ nextDestX + kernDelta.
			lastIndex _ lastIndex + 1].
	lastIndex _ stopIndex.
	^stops at: EndOfRun