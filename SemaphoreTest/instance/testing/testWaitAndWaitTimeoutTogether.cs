testWaitAndWaitTimeoutTogether
	| semaphore value waitProcess waitTimeoutProcess |
	semaphore _ Semaphore new.
	
	waitProcess _ [semaphore wait. value _ #wait] fork.

	waitTimeoutProcess _ [semaphore waitTimeoutMSecs: 50. value _ #waitTimeout] fork.

	"Wait for the timeout to happen"
	(Delay forMilliseconds: 100) wait.

	"The waitTimeoutProcess should already have timed out.  This should release the waitProcess"
	semaphore signal.

	[waitProcess isTerminated and: [waitTimeoutProcess isTerminated]]
		whileFalse: [(Delay forMilliseconds: 100) wait].

	self assert: value = #wait.
	