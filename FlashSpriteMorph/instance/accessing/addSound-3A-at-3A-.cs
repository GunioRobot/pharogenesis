addSound: aSound at: frameNr
	| oldSound newSound |
	oldSound _ sounds at: frameNr ifAbsent:[nil].
	oldSound isNil 
		ifTrue:[newSound _ Array with: aSound]
		ifFalse:[newSound _ oldSound copyWith: newSound].
	sounds at: frameNr put: newSound.