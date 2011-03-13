printOn: aStream base: b "SmallInteger maxVal printStringBase: 2"
	"Refer to the comment in Integer|printOn:base:."
	| i x digitsInReverse |
	(x _ self) < 0 ifTrue: 
			[aStream nextPut: $-.
			^ self negated printOn: aStream base: b].
	b = 10 ifFalse: [aStream print: b; nextPut: $r].
	digitsInReverse _ Array new: 32.
	i _ 0.
	[x >= b]
		whileTrue: 
			[digitsInReverse at: (i _ i + 1) put: x \\ b.
			x _ x // b].
	digitsInReverse at: (i _ i + 1) put: x.
	i to: 1 by: -1 do:
		[:j | aStream nextPut: (Character digitValue: (digitsInReverse at: j))]