updateLiteralLabel
	| myReadout |
	(myReadout _ self labelMorph) ifNil: [^ self].
	myReadout contents: literal stringForReadout.
