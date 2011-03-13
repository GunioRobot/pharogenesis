buildWith: builder
	| windowSpec max listSpec panelSpec textSpec |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'System Browser'.
	windowSpec children: OrderedCollection new.

	self wantsOptionalButtons ifTrue:[max := 0.3] ifFalse:[max := 0.2].
	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #messageList; 
		getIndex: #messageListIndex; 
		setIndex: #messageListIndex:; 
		menu: #messageListMenu:shifted:; 
		keyPress: #messageListKey:from:;
		frame: (0@0 corner: 1@0.2).
	windowSpec children add: listSpec.

	self wantsOptionalButtons ifTrue:[
		panelSpec := self buildOptionalButtonsWith: builder.
		panelSpec frame: (0@0.2 corner: 1@max).
		windowSpec children add: panelSpec.
	].

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #contents; 
		setText: #contents:notifying:; 
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0@max corner: 1@1).
	windowSpec children add: textSpec.

	^builder build: windowSpec