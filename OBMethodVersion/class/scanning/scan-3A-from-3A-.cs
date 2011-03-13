scan: sources from: pointer 
	| versions current |
	
	versions := OrderedCollection new.
	current := OBMethodVersion fromSources: sources andPointer: pointer.
	[current notNil]
		whileTrue: [versions add: current.
					current := current previous].
	^ versions