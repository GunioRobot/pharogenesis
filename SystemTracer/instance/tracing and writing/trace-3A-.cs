trace: obj

	(self hasClamped: obj) ifTrue: [^ self].
	self perform: (writeDict at: obj class ifAbsent: [#writeClamped:])
			"May be some classes not in Smalltalk dict, let them through"
		with: obj.