linesUpToEnd

	| elements ln |
	elements _ OrderedCollection new.
	[(ln _ self nextLine) isNil] whileFalse: [ 
		elements add: ln].
	^elements