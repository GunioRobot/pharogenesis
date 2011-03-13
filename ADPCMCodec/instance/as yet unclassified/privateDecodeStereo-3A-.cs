privateDecodeStereo: count

	| predictedLeft predictedRight indexLeft indexRight deltaLeft deltaRight
	 stepLeft stepRight predictedDeltaLeft predictedDeltaRight bit |

	<primitive: 'primitiveDecodeStereo' module: 'ADPCMPlugin'>
	self var: #stepSizeTable declareC: 'short int *stepSizeTable'.
	self var: #indexTable declareC: 'short int *indexTable'.
	self var: #samples declareC: 'short int *samples'.
	self var: #encodedBytes declareC: 'unsigned char *encodedBytes'.
	self var: #rightSamples declareC: 'short int *rightSamples'.
	self var: #predicted declareC: 'short int *predicted'.
	self var: #index declareC: 'short int *index'.

	"make local copies of decoder state variables"
	predictedLeft _ predicted at: 1.
	predictedRight _ predicted at: 2.
	indexLeft _ index at: 1.
	indexRight _ index at: 2.

	1 to: count do: [:i |
		(i bitAnd: frameSizeMask) = 1
			ifTrue: [  "start of frame; read frame header"
				predictedLeft _ self nextBits: 16.
				indexLeft _ self nextBits: 6.
				predictedRight _ self nextBits: 16.
				indexRight _ self nextBits: 6.
				predictedLeft > 32767 ifTrue: [predictedLeft _ predictedLeft - 65536].
				predictedRight > 32767 ifTrue: [predictedRight _ predictedRight - 65536].
				samples at: (sampleIndex _ sampleIndex + 1) put: predictedLeft.
				rightSamples at: sampleIndex put: predictedRight]
			ifFalse: [
				deltaLeft _ self nextBits: bitsPerSample.
				deltaRight _ self nextBits: bitsPerSample.
				stepLeft _ stepSizeTable at: indexLeft + 1.
				stepRight _ stepSizeTable at: indexRight + 1.
				predictedDeltaLeft _ predictedDeltaRight _ 0.
				bit _ deltaValueHighBit.
				[bit > 0] whileTrue: [
					(deltaLeft bitAnd: bit) > 0 ifTrue: [
						predictedDeltaLeft _ predictedDeltaLeft + stepLeft].
					(deltaRight bitAnd: bit) > 0 ifTrue: [
						predictedDeltaRight _ predictedDeltaRight + stepRight].
					stepLeft _ stepLeft bitShift: -1.
					stepRight _ stepRight bitShift: -1.
					bit _ bit bitShift: -1].
				predictedDeltaLeft _ predictedDeltaLeft + stepLeft.
				predictedDeltaRight _ predictedDeltaRight + stepRight.

				(deltaLeft bitAnd: deltaSignMask) > 0
					ifTrue: [predictedLeft _ predictedLeft - predictedDeltaLeft]
					ifFalse: [predictedLeft _ predictedLeft + predictedDeltaLeft].
				(deltaRight bitAnd: deltaSignMask) > 0
					ifTrue: [predictedRight _ predictedRight - predictedDeltaRight]
					ifFalse: [predictedRight _ predictedRight + predictedDeltaRight].
				predictedLeft > 32767
					ifTrue: [predictedLeft _ 32767]
					ifFalse: [predictedLeft < -32768 ifTrue: [predictedLeft _ -32768]].
				predictedRight > 32767
					ifTrue: [predictedRight _ 32767]
					ifFalse: [predictedRight < -32768 ifTrue: [predictedRight _ -32768]].

				indexLeft _ indexLeft + (indexTable at: (deltaLeft bitAnd: deltaValueMask) + 1).
				indexLeft < 0
					ifTrue: [indexLeft _ 0]
					ifFalse: [indexLeft > 88 ifTrue: [indexLeft _ 88]].
				indexRight _ indexRight + (indexTable at: (deltaRight bitAnd: deltaValueMask) + 1).
				indexRight < 0
					ifTrue: [indexRight _ 0]
					ifFalse: [indexRight > 88 ifTrue: [indexRight _ 88]].

				samples at: (sampleIndex _ sampleIndex + 1) put: predictedLeft.
				rightSamples at: sampleIndex put: predictedRight]].

	"save local copies of decoder state variables"
	predicted at: 1 put: predictedLeft.
	predicted at: 2 put: predictedRight.
	index at: 1 put: indexLeft.
	index at: 2 put: indexRight.
