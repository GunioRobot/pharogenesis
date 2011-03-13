tedsHack  
	"Generate cryptic puzzles from method comments in the system"
	| c s | s _ 'none'.
	[s = 'none'] whileTrue:
		[s _ ((c _ Smalltalk allClasses atRandom) selectors
					collect: [:sel | (c firstCommentAt: sel) asString])
		 			detect: [:str | str size between: 100 and: 200] ifNone: ['none']].
	(CipherPanel quoteToScramble: s) openInWorld

"CipherPanel tedsHack"