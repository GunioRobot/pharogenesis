fullDisplayUpdate
	"Repaint the entire smalltalk screen, ignoring the affected rectangle. Used in some platform's code when the Smalltalk window is brought to the front or uncovered."

	| displayObj w h |
	displayObj _ self splObj: TheDisplay.
	((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]) ifTrue: [
		w _ self fetchInteger: 1 ofObject: displayObj.
		h _ self fetchInteger: 2 ofObject: displayObj.
		self displayBitsOf: displayObj Left: 0 Top: 0 Right: w Bottom: h.
		self ioForceDisplayUpdate].
