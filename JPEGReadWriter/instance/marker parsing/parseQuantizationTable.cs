parseQuantizationTable

	| length markerStart n prec value table |
	markerStart _ self position.
	length _ self nextWord.
	[self position - markerStart >= length] whileFalse:
		[value _ self next.
		n _ (value bitAnd: 16r0F) + 1.
		prec _ (value >> 4) > 0.
		n > QuantizationTableSize
			 ifTrue: [self error: 'image has more than ',
				QuantizationTableSize printString,
				' quantization tables'].
		table _ IntegerArray new: DCTSize2.
		1 to: DCTSize2 do:
			[:i |
			value _ (prec
				ifTrue: [self nextWord]
				ifFalse: [self next]).
			table at: (JPEGNaturalOrder at: i) put: value].
		self useFloatingPoint ifTrue: [self scaleQuantizationTable: table].
		self qTable at: n put: table]