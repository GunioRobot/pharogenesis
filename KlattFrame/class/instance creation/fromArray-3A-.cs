fromArray: anArray
	| answer |
	answer _ self new.
	anArray doWithIndex: [ :each :i | answer at: i put: each].
	^ answer