primitiveKbdNext
	"Return the next keycode and remove it from the input buffer. The low byte is the 8-bit ISO character. The next four bits are the Smalltalk modifier bits <cmd><option><ctrl><shift>."

	| keystrokeWord |
	self pop: 1.
	keystrokeWord _ self ioGetKeystroke.
	keystrokeWord >= 0
		ifTrue: [self pushInteger: keystrokeWord]
		ifFalse: [self push: nilObj].