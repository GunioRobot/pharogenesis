initializeWithInMessage: inMessage0  andOutQueue: aSharedQueue
	inputMessage _ inMessage0.
	outputQueue _ aSharedQueue.
	hasBeenRead _ false.
	hasBeenWritten _ false.