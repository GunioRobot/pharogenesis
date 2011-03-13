testIfNotEmpty

	empty ifNotEmpty: [self assert: false].
	self assert: (nonEmpty ifNotEmpty: [self]) == self.
	self assert: (nonEmpty ifNotEmpty: [:s | s first]) = #x
