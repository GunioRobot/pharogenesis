skipSeparatorsAndComments
	[	self skipSeparators.
		self peekChar = $(
	] whileTrue: [ self skipComment ]