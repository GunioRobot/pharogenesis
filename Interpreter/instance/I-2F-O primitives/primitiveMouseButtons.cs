primitiveMouseButtons
	"Return the mouse button state. The low three bits encode the state of the <red><yellow><blue> mouse buttons. The next four bits encode the Smalltalk modifier bits <cmd><option><ctrl><shift>."

	| buttonWord |
	self pop: 1.
	buttonWord _ self ioGetButtonState.
	self pushInteger: buttonWord.