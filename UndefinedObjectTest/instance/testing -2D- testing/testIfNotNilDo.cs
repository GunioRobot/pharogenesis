testIfNotNilDo
	self shouldnt: [ nil ifNotNilDo: [self halt]] raise: Halt.
