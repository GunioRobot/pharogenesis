addRepository
	self newRepository ifNotNilDo:
		[:repos | self addRepository: repos ].
