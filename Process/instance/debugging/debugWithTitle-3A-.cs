debugWithTitle: title
	"Open a debugger on me"
	"Is this the UI process?"
	self == Processor activeProcess
		ifTrue: [Smalltalk isMorphic
				ifTrue: [[Project interruptName: title] fork]
				ifFalse: [[ScheduledControllers interruptName: title] fork].
			^ self].
	myList isNil
		ifTrue: [^ self]
		ifFalse: [myList
				remove: self
				ifAbsent: [].
			self offList].
	Debugger openInterrupt: title onProcess: self