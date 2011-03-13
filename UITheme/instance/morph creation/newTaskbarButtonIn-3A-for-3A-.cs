newTaskbarButtonIn: aTaskbar for: aWindow
	"Answer a taskbar button morph for the given window."

	|lm lab button labSize|
	labSize := (150 // (aTaskbar tasks size + 1) max: 10) min: 30.
	lab := (self buttonLabelForText: (aWindow taskbarLabel truncateWithElipsisTo: labSize)).
	lm := self
		newRowIn: aTaskbar
		for: {(aWindow taskbarIcon ifNil: [^nil]) asMorph. lab}.
	lm cellInset: 2.
	button := self
		newButtonIn: aTaskbar
		for: aWindow
		getState: #isCollapsed
		action: #taskbarButtonClicked
		arguments: #()
		getEnabled: nil
		label: lm
		help: nil.
	button
		onColor: (self taskbarMinimizedButtonColorFor: button)
		offColor: (aWindow isActive
				ifTrue: [self taskbarActiveButtonColorFor: button]
				ifFalse: [self taskbarButtonColorFor: button]);
		wantsYellowButtonMenu: true;
		getMenuSelector: #taskbarButtonMenu:;
		on: #mouseEnter send: #taskbarButtonEntered:event:in: to: aWindow withValue: button;
		on: #mouseLeave send: #taskbarButtonLeft:event:in: to: aWindow withValue: button.
	lab color: (self taskbarButtonLabelColorFor: button).
	^button