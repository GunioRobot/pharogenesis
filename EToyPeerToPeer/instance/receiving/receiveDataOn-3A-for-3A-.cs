receiveDataOn: aSocket for: aCommunicatorMorph

	socket _ aSocket.
	remoteSocketAddress _ socket remoteAddress.
	communicatorMorph _ aCommunicatorMorph.
	process _ [
		leftOverData _ ''.
		[self doReceiveData] whileTrue.
		socket closeAndDestroy.
	] newProcess.
	process priority: Processor highIOPriority.
	process resume.
