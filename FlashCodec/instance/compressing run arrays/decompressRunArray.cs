decompressRunArray
	| n array runIndex runLength runValue spl c |
	stream next = $+ ifFalse:[self error:'Negative array size'].
	n := Integer readFrom: stream.
	array := ShortRunArray basicNew: n.
	runIndex := 0.
	spl := stream next.
	[runIndex < n] whileTrue:[
		"Read runLength"
		runLength := 0.
		[(c := stream next) isDigit] 
			whileTrue:[runLength := (runLength * 10) + c digitValue].
		spl = $+ ifFalse:[self error:'Negative run length'].
		"Read run value"
		spl := c.
		runValue := 0.
		[(c := stream next) isDigit]
			whileTrue:[runValue := (runValue * 10) + c digitValue].
		spl = $-
			ifTrue:[runValue := 0 - runValue]
			ifFalse:[spl = $+ ifFalse:[self error:'Compression problem']].
		array setRunAt: (runIndex := runIndex+1) toLength: runLength value: runValue.
		spl := c.
	].
	spl = $X ifFalse:[^self error:'Unexpected special character'].
	^array	