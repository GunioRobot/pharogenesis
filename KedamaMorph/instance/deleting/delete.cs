delete

	| c |
	super delete.
	turtlesDict keysDo: [:k |
		self deleteAllTurtlesOfExampler: k.
		c := k costume.
		c ifNotNil: [c renderedMorph delete].
	].

