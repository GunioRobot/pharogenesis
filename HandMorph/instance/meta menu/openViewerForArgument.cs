openViewerForArgument
	(argument notNil and: [self playfield notNil]) ifTrue:
		[argument presenter viewMorph: argument]