processSamples

	| w sel |
	w _ self world.
	self nameInModel ifNil: [^ self].
	sel _ self processSamplesSelector.
	(w model respondsTo: sel) ifFalse: [^ self].
	self cursor: 1.
	[self cursorAtEnd] whileFalse: [
		w model perform: sel.
		w runStepMethods.
		w displayWorld].
	w model perform: sel.  "final sample"
