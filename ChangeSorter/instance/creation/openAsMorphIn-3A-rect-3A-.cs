openAsMorphIn: window rect: rect
	"Add a set of change sorter views to the given top view offset by the given amount. To create a single change sorter, call this once with an offset of 0@0. To create a dual change sorter, call it twice with offsets of 0@0 and 0.5@0."
	| buttonView col |
	contents _ ''.
	self addDependent: window.		"so it will get changed: #relabel"
	buttonView _ PluggableButtonMorph
		on: self
		getState: #mainButtonState
		action: #changeSetMenuStart
		label: #mainButtonName
		menu: #changeSetMenu:.
	col _ Color perform: self defaultBackgroundColor.
	buttonView
		label: myChangeSet name; 
		onColor: col offColor: col;
		triggerOnMouseDown: true; borderColor: window color.
	window addMorph: buttonView
		frame: (((0@0 extent: 1.0@0.06) scaleBy: rect extent) translateBy: rect origin).

	window addMorph: (PluggableListMorphByItem on: self
			list: #classList
			selected: #currentClassName
			changeSelected: #currentClassName:
			menu: #classMenu:)
		frame: (((0@0.06 extent: 0.5@0.3) scaleBy: rect extent) translateBy: rect origin).

	window addMorph: (PluggableListMorphByItem on: self
			list: #messageList
			selected: #currentSelector
			changeSelected: #currentSelector:
			menu: #messageMenu:shifted:
			keystroke: #messageListKey:from:)
		frame: (((0.5@0.06 extent: 0.5@0.3) scaleBy: rect extent) translateBy: rect origin).

	window addMorph: (PluggableTextMorph on: self 
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:)
		frame: (((0@0.36 corner: 1@1) scaleBy: rect extent) translateBy: rect origin).
