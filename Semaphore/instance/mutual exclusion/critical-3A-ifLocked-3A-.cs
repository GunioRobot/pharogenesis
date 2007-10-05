critical: mutuallyExcludedBlock ifLocked: alternativeBlock
	"Evaluate mutuallyExcludedBlock only if the receiver is not currently in 
	the process of running the critical: message. If the receiver is, evaluate 
	mutuallyExcludedBlock after the other critical: message is finished."
	excessSignals == 0 ifTrue:[
		"If we come here, then the semaphore was locked when the test executed. 
		Evaluate the alternative block and answer its result."
		^alternativeBlock value 
	].
	^self critical: mutuallyExcludedBlock