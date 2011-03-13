generateKeyboardEvent: evtBuf
	"Generate the appropriate mouse event for the given raw event buffer"
	| buttons modifiers type keyValue pressType stamp |
	stamp _ (evtBuf at: 2).
	stamp = 0 ifTrue:[stamp _ Time millisecondClockValue].
	keyValue _ evtBuf at: 3.
	pressType _ evtBuf at: 4.
	pressType = EventKeyDown ifTrue:[type _ #keyDown].
	pressType = EventKeyUp ifTrue:[type _ #keyUp].
	pressType = EventKeyChar ifTrue:[type _ #keystroke].
	modifiers _ evtBuf at: 5.
	buttons _ modifiers bitShift: 3.
	^KeyboardEvent new
		setType: type
		buttons: buttons
		position: self position
		keyValue: keyValue
		hand: self
		stamp: stamp