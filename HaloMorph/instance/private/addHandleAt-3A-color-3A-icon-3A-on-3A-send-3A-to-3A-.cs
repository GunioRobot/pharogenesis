addHandleAt: aPoint color: aColor icon: iconName on: eventName send: selector to: recipient
	"Add a handle centered at the given point with the given color, and set it up to respond to the given event by sending the given selector to the given recipient.  Return the handle."
	| handle |
	handle _ EllipseMorph
		newBounds: (Rectangle center: aPoint extent: self handleSize asPoint)
		color: aColor.
	handle borderColor: aColor muchDarker.
	self addMorph: handle.
	iconName ifNotNil:
		[ | form |
		form _ ScriptingSystem formAtKey: iconName.
		form ifNotNil:
			[handle addMorphCentered: (ImageMorph new
				image: form; 
				color: aColor makeForegroundColor;
				lock)]].
	handle on: #mouseUp send: #endInteraction to: self.
	handle on: eventName send: selector to: recipient.
	handle setBalloonText: (target balloonHelpTextForHandle: handle) translated.
	^ handle
