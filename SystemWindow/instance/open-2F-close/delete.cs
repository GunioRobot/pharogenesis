delete
	| thisWorld |
	model okToChange ifFalse: [^self].
	thisWorld _ self world.
	model breakDependents.
	model _ nil.
	super delete.
	SystemWindow noteTopWindowIn: thisWorld