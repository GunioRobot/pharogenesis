printAllStacks
	"Print all the stacks of all running processes, including those that are currently suspended."
	| oop proc ctx |
	proc _ self fetchPointer: ActiveProcessIndex ofObject: self schedulerPointer.
	self printNameOfClass: (self fetchClassOf: proc) count: 5.
	self cr.
	self printCallStackOf: activeContext. "first the active context"
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue:[
		(self fetchClassOf: oop) == self classSemaphore ifTrue:[
			self cr.
			proc _ self fetchPointer: FirstLinkIndex ofObject: oop.
			[proc == self nilObject] whileFalse:[
				self printNameOfClass: (self fetchClassOf: proc) count: 5.
				self cr.
				ctx _ self fetchPointer: SuspendedContextIndex ofObject: proc.
				ctx == self nilObject ifFalse:[self printCallStackOf: ctx].
				proc _ self fetchPointer: NextLinkIndex ofObject: proc].
		].
		oop _ self objectAfter: oop.
	].