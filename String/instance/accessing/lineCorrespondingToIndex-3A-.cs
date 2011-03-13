lineCorrespondingToIndex: anIndex
	"Answer a string containing the line at the given character position.  1/15/96 sw:  Inefficient first stab at this"

	| cr aChar answer |
	cr _ Character cr.
	answer _ ''.
	1 to: self size do:
		[:i | 
			aChar _ self at: i.
			aChar == cr
				ifTrue:
					[i > anIndex
						ifTrue:
							[^ answer]
						ifFalse:
							[answer _ '']]
				ifFalse:
					[answer _ answer copyWith: aChar]].
	^ answer