doMenuItem: menuString
	| aMenu anItem aNominalEvent aHand |
	aMenu _ (aHand _ self currentHand) buildMorphHandleMenuFor: self.
	aMenu allMorphsDo: [:m | m step].  "Get wordings current"
	anItem _ aMenu itemWithWording: menuString.
	anItem ifNil:
		[^ self player scriptingError: 'Menu item not found: ', menuString].
	aHand setArgument: self.
	aNominalEvent _  MorphicEvent new
		setMousePoint: 0@0
		buttons: Sensor primMouseButtons
		lastEvent: aHand lastEvent
		hand: aHand.
	anItem invokeWithEvent: aNominalEvent