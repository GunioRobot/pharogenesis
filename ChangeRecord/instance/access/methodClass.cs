methodClass 
	| methodClass |
	type == #method ifFalse: [^ nil].
	(Smalltalk includesKey: class asSymbol) ifFalse: [^ nil].
	methodClass _ Smalltalk at: class asSymbol.
	meta ifTrue: [^ methodClass class]
		ifFalse: [^ methodClass]