validateMatchAt: pos from: startPos to: endPos
	| here |
	here _ pos.
	startPos+1 to: endPos+1 do:[:i|
		(collection at: i) = (collection at: (here _ here + 1))
			ifFalse:[^self error:'Not a match']].
	^true