scanCharacters

	| left top lastIndex charVal ascii sourceX2 nextDestX |
	scanDisplayFlag ifTrue:
		[self clipRange.  "Need to get true x, y for affectedRectangle"
		left _ dx.
		top _ dy].
	lastIndex _ scanStart.
	[lastIndex <= scanStop]
		whileTrue: [
			charVal _ interpreterProxy stObject: scanString at: lastIndex.
			ascii _ interpreterProxy integerValueOf: charVal.
			interpreterProxy failed ifTrue: [^ nil].
			stopCode _ interpreterProxy stObject: scanStopArray at: ascii + 1.
			interpreterProxy failed ifTrue: [^ nil].
			stopCode = interpreterProxy nilObject
				ifFalse: [^ self returnAt: ascii + 1
							 lastIndex: lastIndex
								  left: left
								  top: top].
			sourceX _ interpreterProxy stObject: scanXTable at: ascii + 1.
			sourceX2 _ interpreterProxy stObject: scanXTable at: ascii + 2.
			interpreterProxy failed ifTrue: [^ nil].
			(interpreterProxy isIntegerObject: sourceX) & (interpreterProxy isIntegerObject: sourceX2)
				ifTrue: [sourceX _ interpreterProxy integerValueOf: sourceX.
						sourceX2 _ interpreterProxy integerValueOf: sourceX2]
				ifFalse: [interpreterProxy primitiveFail. ^ nil].
			nextDestX _ destX + (width _ sourceX2 - sourceX).
			nextDestX > scanRightX
				ifTrue: [^ self returnAt: CrossedX
							 lastIndex: lastIndex
								  left: left
								  top: top].
			scanDisplayFlag ifTrue: [self copyBits].
			destX _ nextDestX.
			interpreterProxy storeInteger: BBDestXIndex ofObject: bitBltOop withValue: destX.
			lastIndex _ lastIndex + 1].
	self returnAt: EndOfRun
		 lastIndex: scanStop
			  left: left
			  top: top