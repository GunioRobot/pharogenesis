testIfEmptyifNotEmptyDo

	self assert: (empty ifEmpty: [true] ifNotEmptyDo: [:s | false]).
	self assert: (nonEmpty ifEmpty: [false] ifNotEmptyDo: [:s | s first = #x])