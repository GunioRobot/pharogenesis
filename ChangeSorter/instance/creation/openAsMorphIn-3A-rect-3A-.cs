openAsMorphIn: window rect: rect
	"Add a set of change sorter views to the given top view offset by the given amount. To create a single change sorter, call this once with an offset of 0@0. To create a dual change sorter, call it twice with offsets of 0@0 and 0.5@0."

	| chgSetList aListMorph |
	contents _ ''.
	self addDependent: window.		"so it will get changed: #relabel"
	window addMorph: (chgSetList _ PluggableListMorphByItem on: self
			list: #changeSetList
			selected: #currentCngSet
			changeSelected: #showChangeSetNamed:
			menu: #changeSetMenu:shifted:
			keystroke: #changeSetListKey:from:)
		frame: (((0@0 extent: 0.5@0.25) scaleBy: rect extent) translateBy: rect origin).
	chgSetList autoDeselect: false.

	window addMorph: (PluggableListMorphByItem on: self
			list: #classList
			selected: #currentClassName
			changeSelected: #currentClassName:
			menu: #classMenu:
			keystroke: #classListKey:from:)
		frame: (((0.5@0 extent: 0.5@0.25) scaleBy: rect extent) translateBy: rect origin).

	aListMorph _ PluggableListMorphByItem on: self
			list: #messageList
			selected: #currentSelector
			changeSelected: #currentSelector:
			menu: #messageMenu:shifted:
			keystroke: #messageListKey:from:.
	aListMorph  menuTitleSelector: #messageListSelectorTitle.
	window addMorph: aListMorph
		frame: (((0@0.25 extent: 1@0.25) scaleBy: rect extent) translateBy: rect origin).

	window addMorph: (PluggableTextMorph on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (((0@0.5 corner: 1@1) scaleBy: rect extent) translateBy: rect origin).
