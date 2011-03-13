addSound: aSound at: frameNr
	| oldSound newSound |
	oldSound := sounds at: frameNr ifAbsent:[nil].
	oldSound isNil 
		ifTrue:[newSound := Array with: aSound]
		ifFalse:[newSound := oldSound copyWith: newSound].
	sounds at: frameNr put: newSound.