testIfNotEmptyDo

	empty ifNotEmptyDo: [:s | self assert: false].
	self assert: (nonEmpty ifNotEmptyDo: [:s | s first]) = #x
