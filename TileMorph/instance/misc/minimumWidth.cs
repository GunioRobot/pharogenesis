minimumWidth
	| aWidth |
	aWidth _ self basicWidth.
	upArrow ifNotNil: [aWidth _ aWidth + UpArrowAllowance].
	suffixArrow ifNotNil: [aWidth _ aWidth + SuffixArrowAllowance].
	^ aWidth
	