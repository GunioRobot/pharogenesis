chasePointers
	| saved |
	selectedProcess
		ifNil: [^ self].
	saved _ selectedProcess.
	[selectedProcess _ nil.
	(Smalltalk includesKey: #PointerFinder)
		ifTrue: [PointerFinder on: saved]
		ifFalse: [self inspectPointers]]
		ensure: [selectedProcess _ saved]