openView: topView offsetBy: offset
	"Add a set of change sorter views to the given top view offset by the given amount. To create a single change sorter, call this once with an offset of 0@0. To create a dual change sorter, call it twice with offsets of 0@0 and 360@0."

	| classView messageView codeView cngSetListView basePane annoPane annoHeight |
	contents _ ''.
	annoHeight _ 20.
	self addDependent: topView. "so it will get changed: #relabel"

	cngSetListView _ PluggableListViewByItem on: self
		list: #changeSetList
		selected: #currentCngSet
		changeSelected: #showChangeSetNamed:
		menu: #changeSetMenu:shifted:
		keystroke: #changeSetListKey:from:.
	cngSetListView window: ((0@0 extent: 180@100) translateBy: offset).
	topView addSubView: cngSetListView.

	classView _ PluggableListViewByItem on: self
		list: #classList
		selected: #currentClassName
		changeSelected: #currentClassName:
		menu: #classMenu:shifted:
		keystroke: #classListKey:from:.
	classView window: ((0@0 extent: 180@100) translateBy: offset).
	topView addSubView: classView toRightOf: cngSetListView.

	messageView _ PluggableListViewByItem on: self
		list: #messageList
		selected: #currentSelector
		changeSelected: #currentSelector:
		menu: #messageMenu:shifted:
		keystroke: #messageListKey:from:.
	messageView menuTitleSelector: #messageListSelectorTitle.
	messageView window: ((0@0 extent: 360@100) translateBy: offset).
	topView addSubView: messageView below: cngSetListView.

	 self wantsAnnotationPane
		ifFalse:
			[basePane _ messageView]
		ifTrue:
			[annoPane _ PluggableTextView on: self
				text: #annotation
				accept: nil
				readSelection: nil
				menu: nil.
			annoPane window: ((0@0 extent: 360@annoHeight) translateBy: offset).
			topView addSubView: annoPane below: messageView.
			basePane _ annoPane].

	codeView _ PluggableTextView on: self 
		text: #contents
		accept: #contents:notifying:
		readSelection: #contentsSelection
		menu: #codePaneMenu:shifted:.
	codeView window: ((0 @ 0 extent: 360 @ 180) translateBy: offset).
	topView addSubView: codeView below: basePane.