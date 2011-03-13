leftAndRighOrNilFor: char 
	| code leftX |
	code := char charCode.
	(code 
		between: self minAscii
		and: self maxAscii) not ifTrue: [ code := $? charCode ].
	leftX := xTable at: code + 1.
	leftX < 0 ifTrue: 
		[ code := $? charCode.
		leftX := xTable at: code + 1 ].
	^ Array 
		with: leftX
		with: (xTable at: code + 2)