associationAtOrAbove: varName ifAbsent: absentBlock 
	"Compatibility with environment protocol."

	self deprecated: 'use associationAt:ifAbsent:'.
	^ self associationAt: varName ifAbsent: absentBlock