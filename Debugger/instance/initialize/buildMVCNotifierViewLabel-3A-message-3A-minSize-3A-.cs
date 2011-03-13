buildMVCNotifierViewLabel: aString message: messageString minSize: aPoint

	| topView notifyView buttonView x y bHeight |
	self expandStack.
	topView _ StandardSystemView new model: self.
	topView borderWidth: 1.
	buttonView _ self buildMVCNotifierButtonView.
	topView addSubView: buttonView.
	notifyView _ PluggableListView on: self
		list: #contextStackList
		selected: #contextStackIndex
		changeSelected: #debugAt:
		menu: nil
		keystroke: nil.
	x _ 350 max: (aPoint x).
	y _ ((4 * 15) + 16) max: (aPoint y - 16 - self optionalButtonHeight).
	bHeight _ self optionalButtonHeight.
	y _ y - bHeight.
	notifyView window: (0@0 extent: x@y).
	topView
		addSubView: notifyView below: buttonView;
		label: aString;
		minimumSize: aPoint.
	^ topView