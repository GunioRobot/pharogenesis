validateAETOrder
	| last next |
	aet isEmpty ifTrue:[^self].
	aet reset.
	last _ aet next.
	[aet atEnd] whileFalse:[
		next _ aet next.
		last xValue <= next xValue ifFalse:[^self error:'AET is broken'].
		last _ next].