addHandle: handleSpec on: eventName send: selector to: recipient
	"Add a handle within the halo box as per the haloSpec, and set it up to respond to the given event by sending the given selector to the given recipient.  Return the handle."
	| handle aPoint iconName colorToUse |
	aPoint _ self positionIn: haloBox horizontalPlacement: handleSpec horizontalPlacement verticalPlacement: handleSpec verticalPlacement.
	handle _ EllipseMorph
		newBounds: (Rectangle center: aPoint extent: self handleSize asPoint)
		color: (colorToUse _ Color colorFrom: handleSpec color).
	handle borderColor: colorToUse muchDarker.
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
	self isMagicHalo ifTrue:[
		handle on: #mouseEnter send: #handleEntered to: self.
		handle on: #mouseLeave send: #handleLeft to: self].
	handle setBalloonText: (target balloonHelpTextForHandle: handle) translated.
	^ handle
