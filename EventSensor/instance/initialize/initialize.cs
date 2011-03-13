initialize
	"Initialize the receiver"
	mouseButtons _ 0.
	mousePosition _ 0@0.
	keyboardBuffer _ SharedQueue new.
	interruptKey _ interruptKey ifNil:[2094].  "cmd-."
	interruptSemaphore _ (Smalltalk specialObjectsArray at: 31) ifNil:[Semaphore new].
	eventQueue _ nil.
	inputProcess _ nil.
	inputSemaphore _ Semaphore new.
