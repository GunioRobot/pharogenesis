bitState: mask incoming: value
	"Set bitState according to the incoming new value.  This covers the mouse buttons 1,2,4 and five keyset bits.  We queue up the red button bit, so that no mouse clicks are lost."
	mask = 1 ifFalse: ["yellow, blue, keyset"
		value = 1
			ifTrue: [bitState _ bitState bitOr: mask]
			ifFalse: [bitState _ bitState bitAnd: -1 - mask]]
	  ifTrue: ["Red button on mouse"
		"bitState must be always the same as the first value on the queue"
		redButtonQueue addLast: value.
		"poll the method mouseButtons will advance the queue"]