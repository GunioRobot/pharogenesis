testHaltIf
	self should: [self haltIf: true] raise: Halt.
	self shouldnt: [self haltIf: false] raise: Halt.

	self should: [self haltIf: [true]] raise: Halt.
	self shouldnt: [self haltIf: [false]] raise: Halt.

	self should: [self haltIf: #testHaltIf.] raise: Halt.
	self shouldnt: [self haltIf: #teadfasdfltIf.] raise: Halt.

	self should: [self a] raise: Halt.
	self shouldnt: [self a1] raise: Halt.

	self should: [self haltIf: [:o | o class = self class]] raise: Halt.
	self shouldnt: [self haltIf: [:o | o class ~= self class]] raise: Halt.
