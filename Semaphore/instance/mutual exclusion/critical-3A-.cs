critical: mutuallyExcludedBlock			
	"Evaluate mutuallyExcludedBlock only if the receiver is not currently in
	the process of running the critical: message. If the receiver is, evaluate
	mutuallyExcludedBlock after the other critical: message is finished."
	| blockValue caught |
	caught := false.
	[
		caught := true.
		self wait.
		blockValue := mutuallyExcludedBlock value
	] ensure: [caught ifTrue: [self signal]].
	^blockValue
