testIfNotEmptyDoifNotEmpty

	self assert: (empty ifNotEmptyDo: [:s | false] ifEmpty: [true]).
	self assert: (nonEmpty ifNotEmptyDo: [:s | s first = #x] ifEmpty: [false])