doAwaitData

	[true] whileTrue: [
		socket _ connectionQueue getConnectionOrNilLenient.
		socket ifNil: [
			(Delay forMilliseconds: 50) wait
		] ifNotNil: [
			self class new receiveDataOn: socket for: communicatorMorph
		]
	].
