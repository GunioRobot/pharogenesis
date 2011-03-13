openView: topView offsetBy: offset
	"Add a set of change sorter views to the given top view offset by the given amount. To create a single change sorter, call this once with an offset of 0@0. To create a dual change sorter, call it twice with offsets of 0@0 and 360@0."
	| classView messageView codeView buttonView |
	contents _ ''.
	self addDependent: topView.		"so it will get changed: #relabel"
	buttonView _ PluggableButtonView
		on: self
		getState: #mainButtonState
		action: #changeSetMenuStart
		label: #mainButtonName
		menu: #changeSetMenu:.
	buttonView
		label: myChangeSet name;
		triggerOnMouseDown: true; borderWidth: 1; 
		window: ((0 @ 0 extent: 360 @ 20) translateBy: offset).
	topView addSubView: buttonView.

	classView _ PluggableListViewByItem on: self
		list: #classList
		selected: #currentClassName
		changeSelected: #currentClassName:
		menu: #classMenu:.
	classView window: (0 @ 0 extent: 180 @ 160).
	topView addSubView: classView below: buttonView.

	messageView _ PluggableListViewByItem on: self
		list: #messageList
		selected: #currentSelector
		changeSelected: #currentSelector:
		menu: #messageMenu:shifted:
		keystroke: #messageListKey:from:.
	messageView window: (0 @ 0 extent: 180 @ 160).
	topView addSubView: messageView toRightOf: classView.

	codeView _ PluggableTextView on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	codeView window: (0 @ 0 extent: 360 @ 180).
	topView addSubView: codeView below: classView.