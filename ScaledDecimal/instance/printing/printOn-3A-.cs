printOn: aStream 
	"Reimplementation - Object 'printing' method."
	| aFraction tmpFractionPart |
	self < 0 ifTrue: [aStream nextPut: $-].
	aFraction := fraction abs.
	aStream nextPutAll: aFraction truncated printString.
	scale = 0 ifTrue: [^ aStream nextPutAll: 's0'].
	aStream nextPut: $..
	tmpFractionPart := aFraction fractionPart.
	1 to: scale
		do: 
			[:dummy | 
			tmpFractionPart := tmpFractionPart * 10.
			aStream nextPut: (Character digitValue: tmpFractionPart truncated).
			tmpFractionPart := tmpFractionPart fractionPart].
	aStream nextPut: $s.
	scale printOn: aStream