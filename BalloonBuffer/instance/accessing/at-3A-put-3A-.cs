at: index put: anInteger
	"For simulation only"
	| word |
	anInteger < 0
		ifTrue:["word _ 16r100000000 + anInteger"
				word _ (anInteger + 1) negated bitInvert32]
		ifFalse:[word _ anInteger].
	self  basicAt: index put: word.
	^anInteger