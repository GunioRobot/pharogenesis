randomComment
	"CipherPanel randomComment"
	"Generate cryptic puzzles from method comments in the system"
	| c s |
	s := 'none'.
	[s = 'none']
		whileTrue: [s := ((c := SystemNavigation new allClasses atRandom) selectors
						collect: [:sel | (c firstCommentAt: sel) asString])
						detect: [:str | str size between: 100 and: 200]
						ifNone: ['none' translated]].
	^ s