fromArray: anArray
	| answer |
	answer := self new.
	anArray doWithIndex: [ :each :i | answer at: i put: each].
	^ answer