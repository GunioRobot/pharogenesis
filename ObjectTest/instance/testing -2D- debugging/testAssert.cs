testAssert
	self shouldnt: [Object assert: [true]] raise: Error.
	self shouldnt: [Object assert: true] raise: Error.

	self should: [Object assert: [false]] raise: AssertionFailure.
	self should: [Object assert: false] raise: AssertionFailure.