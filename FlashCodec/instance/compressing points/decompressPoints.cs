decompressPoints
	"Decompress the points using delta values and RLE compression."
	| pts n index runValue spl runLength c x y |
	n := Integer readFrom: stream.
	n = 0 ifTrue:[^ShortPointArray new].
	n < 0
		ifTrue:[	n := 0 - n.
				pts := PointArray new: n]
		ifFalse:[pts := ShortPointArray new: n].
	index := 0.
	runValue := 0@0.
	"Prefetch special character"
	spl := stream next.
	[index < n] whileTrue:[
		"Read runLength/value"
		spl = $* ifTrue:[
			"Run length follows"
			runLength := 0.
			[(c := stream next) isDigit] 
				whileTrue:[runLength := (runLength * 10) + c digitValue].
			spl := c.
		] ifFalse:[runLength := 1].
		"Check for special zero point"
		(spl = $Z or:[spl = $A]) ifTrue:[
			"Since deltaPt is 0@0 there is no need to update runValue.
			Just prefetch the next special character"
			spl = $A ifTrue:[runLength := 2].
			spl := stream next.
		] ifFalse:["Regular point"
			"Fetch absolute delta x value"
			x := 0.
			[(c := stream next) isDigit] 
				whileTrue:[x := (x * 10) + c digitValue].
			"Sign correct x"
			spl = $- 
				ifTrue:[x := 0 - x]
				ifFalse:[spl = $+ ifFalse:[self error:'Bad special character']].
			spl := c.
			"Fetch absolute delta y value"
			y := 0.
			[(c := stream next) isDigit] 
				whileTrue:[y := (y * 10) + c digitValue].
			"Sign correct y"
			spl = $-
				ifTrue:[y := 0 - y]
				ifFalse:[spl = $+ ifFalse:[self error:'Bad special character']].
			spl := c.
			"Compute absolute run value"
			runValue := runValue + (x@y).
		].
		"And store points"
		1 to: runLength
			do:[:i| pts at: (index := index + 1) put: runValue].
	].
	"Last char must be X"
	spl = $X ifFalse:[self error:'Bad special character'].
	^pts