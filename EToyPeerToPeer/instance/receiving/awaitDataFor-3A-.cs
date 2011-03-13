awaitDataFor: aCommunicatorMorph

	Socket initializeNetwork.
	connectionQueue _ ConnectionQueue 
		portNumber: self class eToyCommunicationsPort 
		queueLength: 6.
	communicatorMorph _ aCommunicatorMorph.
	process _ [self doAwaitData] newProcess.
	process priority: Processor highIOPriority.
	process resume.
