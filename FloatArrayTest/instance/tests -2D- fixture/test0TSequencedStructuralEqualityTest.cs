test0TSequencedStructuralEqualityTest

	self shouldnt: [self nonEmpty at: 1] raise: Error. "Ensures #nonEmpty is sequenceable"