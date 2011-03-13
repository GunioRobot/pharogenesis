privateEncodeMono: count

	| step sign diff delta predictedDelta bit p |
	<primitive: 'primitiveEncodeMono' module: 'ADPCMPlugin'>
	self var: #stepSizeTable declareC: 'short int *stepSizeTable'.
	self var: #indexTable declareC: 'short int *indexTable'.
	self var: #samples declareC: 'short int *samples'.
	self var: #encodedBytes declareC: 'unsigned char *encodedBytes'.

	step _ stepSizeTable at: 1.
	1 to: count do: [:i |
		(i bitAnd: frameSizeMask) = 1 ifTrue: [
			predicted _ samples at: (sampleIndex _ sampleIndex + 1).
			(p _ predicted) < 0 ifTrue: [p _ p + 65536].
			self nextBits: 16 put: p.
			i < count ifTrue: [
				index _ self indexForDeltaFrom: predicted to: (samples at: sampleIndex + 1)].
			self nextBits: 6 put: index.
		] ifFalse: [
			"compute sign and magnitude of difference from the predicted sample"
			sign _ 0.
			diff _ (samples at: (sampleIndex _ sampleIndex + 1)) - predicted.
			diff < 0 ifTrue: [
				sign _ deltaSignMask.
				diff _ 0 - diff].

			"Compute encoded delta and the difference that this will cause in the predicted sample value during decoding. Note that this code approximates:
				delta _ (4 * diff) / step.
				predictedDelta _ ((delta + 0.5) * step) / 4;
			but in the shift step bits are dropped. Thus, even if you have fast mul/div hardware you cannot use it since you would get slightly different bits what than the algorithm defines."
			delta _ 0.
			predictedDelta _ 0.
			bit _ deltaValueHighBit.
			[bit > 0] whileTrue: [
				diff >= step ifTrue: [
					delta _ delta + bit.
					predictedDelta _ predictedDelta + step.
					diff _ diff - step].
				step _ step bitShift: -1.
				bit _ bit bitShift: -1].
			predictedDelta _ predictedDelta + step.

			"compute and clamp new prediction"
			sign > 0
				ifTrue: [predicted _ predicted - predictedDelta]
				ifFalse: [predicted _ predicted + predictedDelta].
			predicted > 32767
				ifTrue: [predicted _ 32767]
				ifFalse: [predicted < -32768 ifTrue: [predicted _ -32768]].

			"compute new index and step values"
			index _ index + (indexTable at: delta + 1).
			index < 0
				ifTrue: [index _ 0]
				ifFalse: [index > 88 ifTrue: [index _ 88]].
			step _ stepSizeTable at: index + 1.

			"output encoded, signed delta"
			self nextBits: bitsPerSample put: (sign bitOr: delta)]].

	bitPosition > 0 ifTrue: [  "flush the last output byte, if necessary"
		encodedBytes at: (byteIndex _ byteIndex + 1) put: currentByte].
