decompressPoints
	"Decompress the points using delta values and RLE compression."
	| pts n index runValue spl runLength c x y |
	n _ Integer readFrom: stream.
	n = 0 ifTrue:[^ShortPointArray new].
	n < 0
		ifTrue:[	n _ 0 - n.
				pts _ PointArray new: n]
		ifFalse:[pts _ ShortPointArray new: n].
	index _ 0.
	runValue _ 0@0.
	"Prefetch special character"
	spl _ stream next.
	[index < n] whileTrue:[
		"Read runLength/value"
		spl = $* ifTrue:[
			"Run length follows"
			runLength _ 0.
			[(c _ stream next) isDigit] 
				whileTrue:[runLength _ (runLength * 10) + c digitValue].
			spl _ c.
		] ifFalse:[runLength _ 1].
		"Check for special zero point"
		(spl = $Z or:[spl = $A]) ifTrue:[
			"Since deltaPt is 0@0 there is no need to update runValue.
			Just prefetch the next special character"
			spl = $A ifTrue:[runLength _ 2].
			spl _ stream next.
		] ifFalse:["Regular point"
			"Fetch absolute delta x value"
			x _ 0.
			[(c _ stream next) isDigit] 
				whileTrue:[x _ (x * 10) + c digitValue].
			"Sign correct x"
			spl = $- 
				ifTrue:[x _ 0 - x]
				ifFalse:[spl = $+ ifFalse:[self error:'Bad special character']].
			spl _ c.
			"Fetch absolute delta y value"
			y _ 0.
			[(c _ stream next) isDigit] 
				whileTrue:[y _ (y * 10) + c digitValue].
			"Sign correct y"
			spl = $-
				ifTrue:[y _ 0 - y]
				ifFalse:[spl = $+ ifFalse:[self error:'Bad special character']].
			spl _ c.
			"Compute absolute run value"
			runValue _ runValue + (x@y).
		].
		"And store points"
		1 to: runLength
			do:[:i| pts at: (index _ index + 1) put: runValue].
	].
	"Last char must be X"
	spl = $X ifFalse:[self error:'Bad special character'].
	^pts