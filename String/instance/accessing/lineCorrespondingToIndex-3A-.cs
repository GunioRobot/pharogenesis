lineCorrespondingToIndex: anIndex
	"Answer a string containing the line at the given character position.  1/15/96 sw:  Inefficient first stab at this"

	| cr aChar answer |
	cr := Character cr.
	answer := ''.
	1 to: self size do:
		[:i | 
			aChar := self at: i.
			aChar = cr
				ifTrue:
					[i > anIndex
						ifTrue:
							[^ answer]
						ifFalse:
							[answer := '']]
				ifFalse:
					[answer := answer copyWith: aChar]].
	^ answer