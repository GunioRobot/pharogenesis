doMenuItem: menuString
	| aMenu anItem aNominalEvent aHand |
	aMenu _ self buildHandleMenu: (aHand _ self currentHand).
	aMenu allMorphsDo: [:m | m step].  "Get wordings current"
	anItem _ aMenu itemWithWording: menuString.
	anItem ifNil:
		[^ self player scriptingError: 'Menu item not found: ', menuString].
	aNominalEvent _  MouseButtonEvent new
		setType: #mouseDown
		position: anItem bounds center
		which: 4 "red"
		buttons: 4 "red"
		hand: aHand
		stamp: nil.
	anItem invokeWithEvent: aNominalEvent