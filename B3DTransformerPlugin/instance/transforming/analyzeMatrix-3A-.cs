analyzeMatrix: m
	"Analyze the matrix and return the appropriate flags"
	| flags |
	self var: #m declareC:'float *m'.
	"Check the perspective"
	flags _ 0.
	((m at: 12) = 0.0 and:[(m at: 13) = 0.0 and:[(m at: 14) = 0.0 and:[(m at: 15) = 1.0]]]) ifTrue:[
		flags _ flags bitOr: FlagM44NoPerspective.
		"Check translation"
		((m at: 3) = 0.0 and:[(m at: 7) = 0.0 and:[(m at: 11) = 0.0]]) ifTrue:[
			flags _ flags bitOr: FlagM44NoTranslation.
			"Check for identity"
			((m at: 0) = 1.0 and:[(m at: 5) = 1.0 and:[(m at: 10) = 1.0 and:[
				(m at: 1) = 0.0 and:[(m at: 2) = 0.0 and:[
				(m at: 4) = 0.0 and:[(m at: 6) = 0.0 and:[
				(m at: 8) = 0.0 and:[(m at: 9) = 0.0]]]]]]]]) ifTrue:[
					flags _ flags bitOr: FlagM44Identity.
			].
		].
	].
	^flags