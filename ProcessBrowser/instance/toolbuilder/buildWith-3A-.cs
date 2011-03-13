buildWith: builder
	"Create a pluggable version of me, answer a window"
	| windowSpec listSpec textSpec |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'Process Browser'.
	windowSpec children: OrderedCollection new.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #processNameList; 
		getIndex: #processListIndex; 
		setIndex: #processListIndex:; 
		menu: #processListMenu:; 
		keyPress: #processListKey:from:;
		frame: (0 @ 0 extent: 0.5 @ 0.5).
	windowSpec children add: listSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #stackNameList; 
		getIndex: #stackListIndex; 
		setIndex: #stackListIndex:; 
		menu: #stackListMenu:; 
		keyPress: #stackListKey:from:;
		frame: (0.5 @ 0.0 extent: 0.5 @ 0.5).
	windowSpec children add: listSpec.

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #selectedMethod; 
		setText: nil; 
		selection: nil; 
		menu: nil;
		frame: (0 @ 0.5 corner: 1 @ 1).
	windowSpec children add: textSpec.

	^builder build: windowSpec