signal: aSymbolOrNil
	"One process waiting for the given event is woken up. If there is no process waiting 
	for this specific event, a process waiting for the default event gets resumed."

	| queue |
	self checkOwnerProcess.
	queue _ self queueFor: aSymbolOrNil.
	queue isEmpty ifTrue: [queue _ self defaultQueue].
	self signalQueue: queue.