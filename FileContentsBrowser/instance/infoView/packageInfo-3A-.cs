packageInfo: p
	| nClasses newClasses oldClasses |
	p isNil ifTrue:[^''].
	nClasses := newClasses := oldClasses := 0.
	p classes do:[:cls|
		nClasses := nClasses + 1.
		(Smalltalk includesKey: (cls name asSymbol))
			ifTrue:[oldClasses := oldClasses + 1]
			ifFalse:[newClasses := newClasses + 1]].
	^nClasses printString,' classes (', newClasses printString, ' new / ', oldClasses printString, ' modified)'