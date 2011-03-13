sendSomeData: arrayOfByteObjects to: anIPAddress for: aCommunicatorMorph multiple: aBoolean

	Socket initializeNetwork.
	socket _ Socket newTCP.
	dataQueue _ SharedQueue new.
	dataQueue nextPut: arrayOfByteObjects.
	communicatorMorph _ aCommunicatorMorph.
	ipAddress _ anIPAddress.
	process _ [
		self doConnectForSend ifTrue: [
			[self doSendData] whileTrue.
			communicatorMorph commResult: {#message -> 'OK'}.
			socket closeAndDestroy.
		].
	] newProcess.
	process priority: Processor highIOPriority.
	process resume.
	^dataQueue
