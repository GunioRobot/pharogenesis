addHandle: handleSpec on: eventName send: selector to: recipient
	"Add a handle within the halo box as per the haloSpec, and set it up to respond to the given event by sending the given selector to the given recipient.  Return the handle."
	| handle aPoint iconName colorToUse |
	aPoint _ self positionIn: haloBox horizontalPlacement: handleSpec horizontalPlacement verticalPlacement: handleSpec verticalPlacement.
	handle _ EllipseMorph
		newBounds: (Rectangle center: aPoint extent: HandleSize asPoint)
		color: (colorToUse _ Color colorFrom: handleSpec color).
	self addMorph: handle.
	(iconName _ handleSpec iconSymbol) ifNotNil:
		[ | form |
		form _ ScriptingSystem formAtKey: iconName.
		form ifNotNil:
			[handle addMorphCentered: (ImageMorph new
				image: form; 
				color: colorToUse makeForegroundColor;
				lock)]].
	handle on: #mouseUp send: #endInteraction to: self.
	handle on: eventName send: selector to: recipient.
	handle setBalloonText: (target balloonHelpTextForHandle: handle).
	^ handle
