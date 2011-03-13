testIfNotEmptyifEmpty

	self assert: (empty ifEmpty: [true] ifNotEmpty: [false]).
	self assert: (nonEmpty ifEmpty: [false] ifNotEmpty: [true]).
	self assert: (nonEmpty ifEmpty: [false] ifNotEmpty: [:s | s first = #x])