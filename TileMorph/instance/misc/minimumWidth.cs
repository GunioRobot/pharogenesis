minimumWidth
	| aWidth |
	aWidth _ self class defaultW.
	upArrow ifNotNil: [aWidth _ aWidth + UpArrowAllowance].
	suffixArrow ifNotNil: [aWidth _ aWidth + SuffixArrowAllowance].
	^ aWidth
	