morphicWindow
	"Create a Browser that lets you type part of a selector, shows a list of selectors, shows the classes of the one you chose, and spawns a full browser on it.  Answer the window
	SelectorBrowser new open "

	| window typeInView selectorListView classListView |
	window _ (SystemWindow labelled: 'later') model: self.
	window setStripeColorsFrom: self defaultBackgroundColor.
	selectorIndex _ classListIndex _ 0.

	typeInView _ PluggableTextMorph on: self 
		text: #contents accept: #contents:notifying:
		readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	typeInView acceptOnCR: true.
	window addMorph: typeInView frame: (0@0 corner: 0.5@0.14).

	selectorListView _ PluggableListMorph on: self
		list: #messageList
		selected: #messageListIndex
		changeSelected: #messageListIndex:
		menu: #selectorMenu:
		keystroke: #messageListKey:from:.
	selectorListView menuTitleSelector: #selectorMenuTitle.
	window addMorph: selectorListView frame: (0@0.14 corner: 0.5@0.6).

	classListView _ PluggableListMorph on: self
		list: #classList
		selected: #classListIndex
		changeSelected: #classListIndex:
		menu: nil
		keystroke: #arrowKey:from:.
	classListView menuTitleSelector: #classListSelectorTitle.
	window addMorph: classListView frame: (0.5@0 corner: 1@0.6).
	window addMorph: ((PluggableTextMorph on: self text: #byExample 
				accept: #byExample:
				readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
					askBeforeDiscardingEdits: false)
		frame: (0@0.6 corner: 1@1).

	window setLabel: 'Method Finder'.
	^ window