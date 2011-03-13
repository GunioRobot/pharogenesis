processEvents
	"Play back the next event"
	| evt hadMouse hadAny |
	hadMouse _ hadAny _ false.
	[(evt _ recorder nextEventToPlay) == nil] whileFalse:[
		evt type == #EOF ifTrue: [recorder pauseIn: self world. ^self].
		evt type == #startSound ifTrue: [evt argument play.  recorder synchronize.  ^ self].
		evt isMouse ifTrue:[hadMouse _ true].
		(evt isMouse or:[evt isKeyboard]) ifTrue:[
			self handleEvent: (evt setHand: self) resetHandlerFields.
			hadAny _ true].
	].
	(mouseClickState notNil and:[hadMouse not]) ifTrue:[
		"No mouse events during this cycle. Make sure click states time out accordingly"
		mouseClickState handleEvent: lastMouseEvent asMouseMove from: self].
	hadAny ifFalse:[
		"No pending events. Make sure z-order is up to date"
		self mouseOverHandler processMouseOver: lastMouseEvent.
	].
