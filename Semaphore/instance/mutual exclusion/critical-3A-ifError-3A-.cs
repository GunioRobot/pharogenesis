critical: mutuallyExcludedBlock ifError: errorBlock
	"Evaluate mutuallyExcludedBlock only if the receiver is not currently in 
	the process of running the critical: message. If the receiver is, evaluate 
	mutuallyExcludedBlock after the other critical: message is finished."

	| blockValue hasError errMsg errRcvr |
	self wait.
	hasError _ false.
	blockValue _ [mutuallyExcludedBlock value] ifError:[:msg :rcvr|
		hasError _ true.
		errMsg _ msg.
		errRcvr _ rcvr].
	hasError ifTrue:[
		self signal.
		^errorBlock value: errMsg value: errRcvr].
	self signal.
	^blockValue