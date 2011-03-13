privateDecodeMono: count

	| delta step predictedDelta bit |
	<primitive: 'primitiveDecodeMono' module: 'ADPCMPlugin'>
	self var: #stepSizeTable declareC: 'short int *stepSizeTable'.
	self var: #indexTable declareC: 'short int *indexTable'.
	self var: #samples declareC: 'short int *samples'.
	self var: #encodedBytes declareC: 'unsigned char *encodedBytes'.

	1 to: count do: [:i |
		(i bitAnd: frameSizeMask) = 1
			ifTrue: [  "start of frame; read frame header"
				predicted _ self nextBits: 16.
				predicted > 32767 ifTrue: [predicted _ predicted - 65536].
				index _ self nextBits: 6.
				samples at: (sampleIndex _ sampleIndex + 1) put: predicted]
			ifFalse: [
				delta _ self nextBits: bitsPerSample.
				step _ stepSizeTable at: index + 1.
				predictedDelta _ 0.
				bit _ deltaValueHighBit.
				[bit > 0] whileTrue: [
					(delta bitAnd: bit) > 0 ifTrue: [predictedDelta _ predictedDelta + step].
					step _ step bitShift: -1.
					bit _ bit bitShift: -1].
				predictedDelta _ predictedDelta + step.

				(delta bitAnd: deltaSignMask) > 0
					ifTrue: [predicted _ predicted - predictedDelta]
					ifFalse: [predicted _ predicted + predictedDelta].
				predicted > 32767
					ifTrue: [predicted _ 32767]
					ifFalse: [predicted < -32768 ifTrue: [predicted _ -32768]].

				index _ index + (indexTable at: (delta bitAnd: deltaValueMask) + 1).
				index < 0
					ifTrue: [index _ 0]
					ifFalse: [index > 88 ifTrue: [index _ 88]].

				samples at: (sampleIndex _ sampleIndex + 1) put: predicted]].
