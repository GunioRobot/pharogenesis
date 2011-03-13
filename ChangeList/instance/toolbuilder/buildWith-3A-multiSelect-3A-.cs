buildWith: builder multiSelect: multiSelect 
	"Open a morphic view for the messageSet, whose label is labelString. 
	The listView may be either single or multiple selection type"

	| windowSpec max listSpec panelSpec textSpec |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'System Browser'.
	windowSpec children: OrderedCollection new.

	max := self wantsOptionalButtons ifTrue:[0.33] ifFalse:[0.4].

	multiSelect ifTrue:[
		listSpec := builder pluggableMultiSelectionListSpec new.
		listSpec getSelectionList: #listSelectionAt:.
		listSpec setSelectionList: #listSelectionAt:put:.
	] ifFalse:[
		listSpec := builder pluggableListSpec new.
	].

	listSpec 
		model: self;
		list: #list; 
		getIndex: #listIndex; 
		setIndex: #toggleListIndex:; 
		menu: (self showsVersions ifTrue: [#versionsMenu:] ifFalse: [#changeListMenu:]); 
		keyPress: #changeListKey:from:;
		frame: (0@0 corner: 1@max).
	windowSpec children add: listSpec.

	self wantsOptionalButtons ifTrue:[
		panelSpec := self buildOptionalButtonsWith: builder.
		panelSpec frame: (0@0.33 corner: 1@0.4).
		windowSpec children add: panelSpec.
	].

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #contents; 
		setText: #contents:;
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0@0.4corner: 1@1).
	windowSpec children add: textSpec.

	^builder build: windowSpec