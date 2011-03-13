readOnlyFileFullyNamed: t1 
	| t3 |
	t3 := self new open: t1 forWrite: false.
	^ t3 isNil
		ifTrue: [((FileDoesNotExistException fileName: t1)
				readOnly: true) signal]
		ifFalse: [t3]