dropAllTheWay

	self running ifFalse: [^ self].
	[currentBlock dropByOne] whileTrue: [
		self score: score + 1
	].
