associationAtOrAbove: varName ifAbsent: absentBlock 
	"Compatibility with environment protocol."

	^ self associationAt: varName ifAbsent: absentBlock