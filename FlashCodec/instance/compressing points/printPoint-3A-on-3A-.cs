printPoint: aPoint on: aStream
	aPoint x < 0
		ifTrue:[aStream print: aPoint x]
		ifFalse:[aStream nextPut: $+; print: aPoint x].
	aPoint y < 0
		ifTrue:[aStream print: aPoint y]
		ifFalse:[aStream nextPut: $+; print: aPoint y].