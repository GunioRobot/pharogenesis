handleEvent: evt
	
	eventSubscribers do: [:m | m handleEvent: evt].
"--"
	(evt anyButtonPressed and:
	 [evt controlKeyPressed and:
	 [lastEvent anyButtonPressed not]]) ifTrue:
		[eventTransform _ MorphicTransform identity.
		lastEvent _ evt.
		^ self invokeMetaMenu: evt].

		evt blueButtonPressed ifTrue:
			[lastEvent blueButtonPressed 
				ifTrue: [^ self specialDrag: evt]
				ifFalse: [eventTransform _ MorphicTransform identity.
						lastEvent _ evt.
						^ self specialGesture: evt]].
"--"
	lastEvent _ evt.
	self position ~= evt cursorPoint
		ifTrue: [self position: evt cursorPoint].

	evt isMouse ifTrue: [
		evt isMouseMove ifTrue: [^ self handleMouseMove: evt].
		self world validateMouseEvent: evt.	"allow current world to bail out"
		evt isMouseDown ifTrue: [ ^ self handleMouseDown: evt].
		evt isMouseUp ifTrue: [^ self handleMouseUp: evt]
	].

	evt isKeystroke ifTrue: [
		keyboardFocus ifNotNil: [keyboardFocus keyStroke: evt].
		^ self].
