buildWith: builder
	"Create the ui for the browser"
	| windowSpec listSpec textSpec buttonSpec panelSpec max |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'System Browser'.
	windowSpec children: OrderedCollection new.

	max := self wantsOptionalButtons ifTrue:[0.43] ifFalse:[0.5].
	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #systemCategoryList; 
		getIndex: #systemCategoryListIndex; 
		setIndex: #systemCategoryListIndex:; 
		menu: #packageListMenu:; 
		keyPress: #packageListKey:from:;
		frame: (0@0 corner: 0.25@max).
	windowSpec children add: listSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #classList; 
		getIndex: #classListIndex; 
		setIndex: #classListIndex:; 
		menu: #classListMenu:; 
		keyPress: #classListKey:from:;
		frame: (0.25@0 corner: 0.5@(max-0.1)).
	windowSpec children add: listSpec.

	panelSpec := builder pluggablePanelSpec new.
	panelSpec frame: (0.25@(max-0.1) corner: 0.5@max).
	panelSpec children: OrderedCollection new.
	windowSpec children addLast: panelSpec.

		buttonSpec := builder pluggableButtonSpec new.
		buttonSpec 
			model: self;
			label: 'instance'; 
			state: #instanceMessagesIndicated; 
			action: #indicateInstanceMessages;
			frame: (0@0 corner: 0.4@1).
		panelSpec children addLast: buttonSpec.

		buttonSpec := builder pluggableButtonSpec new.
		buttonSpec 
			model: self;
			label: '?'; 
			state: #classCommentIndicated; 
			action: #plusButtonHit;
			frame: (0.4@0 corner: 0.6@1).
		panelSpec children addLast: buttonSpec.

		buttonSpec := builder pluggableButtonSpec new.
		buttonSpec 
			model: self;
			label: 'class'; 
			state: #classMessagesIndicated; 
			action: #indicateClassMessages;
			frame: (0.6@0 corner: 1@1).
		panelSpec children addLast: buttonSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #messageCategoryList; 
		getIndex: #messageCategoryListIndex; 
		setIndex: #messageCategoryListIndex:; 
		menu: #messageCategoryMenu:; 
		keyPress: #arrowKey:from:;
		frame: (0.5@0 corner: 0.75@max).
	windowSpec children add: listSpec.

	listSpec := builder pluggableListSpec new.
	listSpec 
		model: self;
		list: #messageList; 
		getIndex: #messageListIndex; 
		setIndex: #messageListIndex:; 
		menu: #messageListMenu:shifted:; 
		keyPress: #messageListKey:from:;
		frame: (0.75@0 corner: 1@max).
	windowSpec children add: listSpec.

	self wantsOptionalButtons ifTrue:[
		panelSpec := self buildOptionalButtonsWith: builder.
		panelSpec frame: (0@0.43 corner: 1@0.5).
		windowSpec children add: panelSpec.
	].

	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #contents; 
		setText: #contents:notifying:; 
		selection: #contentsSelection; 
		menu: #codePaneMenu:shifted:;
		frame: (0@0.5corner: 1@0.92).
	windowSpec children add: textSpec.

	textSpec := builder pluggableInputFieldSpec new.
	textSpec 
		model: self;
		getText: #infoViewContents; 
		frame: (0@0.92corner: 1@1).
	windowSpec children add: textSpec.

	^builder build: windowSpec