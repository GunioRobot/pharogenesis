runCase

	self setUp.
	[self perform: self testMessage]
		ensure: [self tearDown].