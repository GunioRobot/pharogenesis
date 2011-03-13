chasePointers
	| saved |
	selectedProcess
		ifNil: [^ self].
	saved := selectedProcess.
	[selectedProcess := nil.
	(Smalltalk includesKey: #PointerFinder)
		ifTrue: [PointerFinder on: saved]
		ifFalse: [self inspectPointers]]
		ensure: [selectedProcess := saved]