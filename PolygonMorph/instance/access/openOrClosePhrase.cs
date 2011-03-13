openOrClosePhrase
	| curveName |
	curveName _ self isCurve ifTrue: ['curve'] ifFalse: ['polygon'].
	^ closed
		ifTrue: ['make open ' , curveName]
		ifFalse: ['make closed ' , curveName]