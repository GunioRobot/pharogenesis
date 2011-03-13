buildMVCNotifierViewLabel: aString message: messageString minSize: aPoint

	| topView notifyView buttonView x y bHeight |
	self expandStack.
	topView := StandardSystemView new model: self.
	topView borderWidth: 1.
	buttonView := self buildMVCNotifierButtonView.
	topView addSubView: buttonView.
	notifyView := PluggableListView on: self
		list: #contextStackList
		selected: #contextStackIndex
		changeSelected: #debugAt:
		menu: nil
		keystroke: nil.
	x := 350 max: (aPoint x).
	y := ((4 * 15) + 16) max: (aPoint y - 16 - self optionalButtonHeight).
	bHeight := self optionalButtonHeight.
	y := y - bHeight.
	notifyView window: (0@0 extent: x@y).
	topView
		addSubView: notifyView below: buttonView;
		label: aString;
		minimumSize: aPoint.
	^ topView