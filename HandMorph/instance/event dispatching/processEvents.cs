processEvents
	"Process user input events from the local input devices."

	| griddedPoint evt currentExtent |
	griddedPoint _ Sensor cursorPoint - owner viewBox topLeft.
	gridOn ifTrue: [griddedPoint _ griddedPoint grid: grid].

	evt _ MorphicEvent new
		setMousePoint: griddedPoint
		buttons: Sensor primMouseButtons
		lastEvent: lastEvent
		hand: self.

	remoteConnections size > 0 ifTrue: [
		currentExtent _ self worldBounds extent.
		lastWorldExtent ~= currentExtent ifTrue: [
			self transmitEvent: (MorphicEvent newWorldExtent: currentExtent).
			lastWorldExtent _ currentExtent].
		self transmitEvent: evt].

	(evt yellowButtonPressed and:
	 [lastEvent yellowButtonPressed not]) ifTrue: [
		lastEvent _ evt.
		^ self invokeMetaMenu: evt].

	(evt blueButtonPressed and:
	 [lastEvent blueButtonPressed not]) ifTrue: [
		lastEvent _ evt.
		^ self specialGesture: evt].

	lastEvent _ evt.
	self handleEvent: evt.

	[Sensor keyboardPressed] whileTrue: [
		evt _ MorphicEvent new
			setKeyValue: Sensor keyboard asciiValue
			mousePoint: griddedPoint
			buttons: Sensor primMouseButtons
			hand: self.
		lastEvent _ evt.
		self handleEvent: evt.
		remoteConnections size > 0 ifTrue: [self transmitEvent: evt]].
