altStyleTester

	self doFirstThatWorks
		if: [self = 1] do: [self + 1];
		if: [self = 2] do: [self + 2];
		if: [self = 3] do: [self + 3];
		if: [self = 4] do: [self + 4];
		if: [true] do: [self + 5]
	
	