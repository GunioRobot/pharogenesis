fullDisplayUpdate
	"Repaint the entire smalltalk screen, ignoring the affected rectangle. Used when the Smalltalk window is brought to the front or uncovered."

	| displayObj dispBits w h dispBitsIndex d |
	displayObj _ self splObj: TheDisplay.
	((self isPointers: displayObj) and: [(self lengthOf: displayObj) >= 4]) ifTrue: [
		dispBits _ self fetchPointer: 0 ofObject: displayObj.
		w _ self fetchInteger: 1 ofObject: displayObj.
		h _ self fetchInteger: 2 ofObject: displayObj.
		d _ self fetchInteger: 3 ofObject: displayObj.
		dispBitsIndex _ dispBits + BaseHeaderSize.  "index in memory byte array"
		self cCode: 'ioShowDisplay(dispBitsIndex, w, h, d, 0, w, 0, h)'.
	].