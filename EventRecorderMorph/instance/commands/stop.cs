stop

	state = #record ifTrue:
		[tape _ tapeStream contents.
		saved _ false].
	journalFile ifNotNil:
		[journalFile close].
	self pauseIn: self world.
	tapeStream _ nil.
	state _ nil.
	statusLight color: Color green.
	recordMeter ifNotNil: [recordMeter width: 1].

	self checkTape.