decompressRunArray
	| n array runIndex runLength runValue spl c |
	stream next = $+ ifFalse:[self error:'Negative array size'].
	n _ Integer readFrom: stream.
	array _ ShortRunArray basicNew: n.
	runIndex _ 0.
	spl _ stream next.
	[runIndex < n] whileTrue:[
		"Read runLength"
		runLength _ 0.
		[(c _ stream next) isDigit] 
			whileTrue:[runLength _ (runLength * 10) + c digitValue].
		spl = $+ ifFalse:[self error:'Negative run length'].
		"Read run value"
		spl _ c.
		runValue _ 0.
		[(c _ stream next) isDigit]
			whileTrue:[runValue _ (runValue * 10) + c digitValue].
		spl = $-
			ifTrue:[runValue _ 0 - runValue]
			ifFalse:[spl = $+ ifFalse:[self error:'Compression problem']].
		array setRunAt: (runIndex _ runIndex+1) toLength: runLength value: runValue.
		spl _ c.
	].
	spl = $X ifFalse:[^self error:'Unexpected special character'].
	^array	