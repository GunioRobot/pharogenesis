signalException: anException
	"Signal an exception in the receiver process...if the receiver is currently
	suspended, the exception will get signaled when the receiver is resumed.  If 
	the receiver is blocked on a Semaphore, it will be immediately re-awakened
	and the exception will be signaled; if the exception is resumed, then the receiver
	will return to a blocked state unless the blocking Semaphore has excess signals"

	"If we are the active process, go ahead and signal the exception"
	self isActiveProcess ifTrue: [^anException signal].

	"Add a new method context to the stack that will signal the exception"
	suspendedContext := MethodContext
		sender: suspendedContext
		receiver: self
		method: (self class methodDict at: #pvtSignal:list:)
		arguments: (Array with: anException with: myList).

	"If we are on a list to run, then suspend and restart the receiver 
	(this lets the receiver run if it is currently blocked on a semaphore).  If
	we are not on a list to be run (i.e. this process is suspended), then when the
	process is resumed, it will signal the exception"

	myList ifNotNil: [self suspend; resume].