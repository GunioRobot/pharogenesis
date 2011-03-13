buildFullWith: builder
	| windowSpec listSpec textSpec panelSpec extent |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'Debugger'.
	Display height < 800 "a small screen" 
		ifTrue:[extent := RealEstateAgent standardWindowExtent]
		ifFalse:[extent := 600@700].
	windowSpec extent: extent.
	windowSpec children: OrderedCollection new.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #contextStackList; 
		getIndex: #contextStackIndex; 
		setIndex: #toggleContextStackIndex:; 
		menu: #contextStackMenu:shifted:; 
		keyPress: #contextStackKey:from:;
		frame: (0@0 corner: 1@0.25).
	windowSpec children add: listSpec.


	panelSpec := self buildOptionalButtonsWith: builder.
	panelSpec frame: (0@0.25 corner: 1@0.3).
	windowSpec children add: panelSpec.

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #contents; 
		setText: #contents:notifying:; 
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0@0.3corner: 1@0.8).
	windowSpec children add: textSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self receiverInspector;
		list: #fieldList; 
		getIndex: #selectionIndex; 
		setIndex: #toggleIndex:; 
		menu: #fieldListMenu:; 
		keyPress: #inspectorKey:from:;
		frame: (0@0.8 corner: 0.2@1).
	windowSpec children add: listSpec.

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self receiverInspector;
		getText: #contents; 
		setText: #accept:; 
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0.2@0.8 corner: 0.5@1).
	windowSpec children add: textSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self contextVariablesInspector;
		list: #fieldList; 
		getIndex: #selectionIndex; 
		setIndex: #toggleIndex:; 
		menu: #fieldListMenu:; 
		keyPress: #inspectorKey:from:;
		frame: (0.5@0.8 corner: 0.7@1).
	windowSpec children add: listSpec.

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self contextVariablesInspector;
		getText: #contents; 
		setText: #accept:; 
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0.7@0.8 corner: 1@1).
	windowSpec children add: textSpec.

	^builder build: windowSpec