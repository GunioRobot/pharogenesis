runCase: aTestCase

	self runCount: self runCount + 1.
	[[aTestCase runCase]		on: self testFailureException do: [:ex |
			self failures add: aTestCase]]
		on: Error do: [:ex |
			self errors add: aTestCase].