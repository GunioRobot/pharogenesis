writeContext: obj
	"Nil out any garbage above the stack pointer to avoid a crash."
	obj stackPtr == nil ifFalse:
		[obj stackPtr+1 to: obj size do: [:ind | obj at: ind put: nil]].
	^ self writePointers: obj	"Normal Case"