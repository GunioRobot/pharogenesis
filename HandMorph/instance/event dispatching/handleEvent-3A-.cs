handleEvent: evt

	self position ~= evt cursorPoint
		ifTrue: [self position: evt cursorPoint].
	temporaryCursor ifNotNil: [
		evt setCursorPoint: evt cursorPoint + temporaryCursorOffset].
	eventSubscribers do: [:m | m handleEvent: evt].
	evt isMouse ifTrue: [
		evt isMouseMove ifTrue: [^ self handleMouseMove: evt].
		evt isMouseDown ifTrue: [^ self handleMouseDown: evt].
		evt isMouseUp ifTrue: [^ self handleMouseUp: evt]].

	evt isKeystroke ifTrue: [
		keyboardFocus ifNotNil: [keyboardFocus keyStroke: evt].
		^ self].
