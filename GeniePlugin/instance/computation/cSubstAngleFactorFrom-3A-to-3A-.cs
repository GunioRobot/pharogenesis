cSubstAngleFactorFrom: startDegreeNumber to: endDegreeNumber 
	| absDiff |
	absDiff _ (endDegreeNumber - startDegreeNumber) abs.
	absDiff > 180 ifTrue: [absDiff _ 360 - absDiff].
	^ absDiff * absDiff bitShift: -6