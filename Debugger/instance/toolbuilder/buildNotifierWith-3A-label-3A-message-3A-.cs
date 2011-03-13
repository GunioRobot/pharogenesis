buildNotifierWith: builder label: label message: messageString
	| windowSpec listSpec textSpec panelSpec buttonSpec |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec extent: 450 @ 156. "nice and wide to show plenty of the error msg"
	windowSpec label: label.
	windowSpec children: OrderedCollection new.

	panelSpec := builder pluggablePanelSpec new.
	panelSpec children: OrderedCollection new.
	self preDebugButtonQuads do:[:spec|
		buttonSpec := builder pluggableButtonSpec new.
		buttonSpec model: self.
		buttonSpec label: spec first.
		buttonSpec action: spec second.
		buttonSpec help: spec fourth.
		panelSpec children add: buttonSpec.
	].
	panelSpec layout: #horizontal. "buttons"
	panelSpec frame: (0@0 corner: 1@0.2).
	windowSpec children add: panelSpec.

	Preferences eToyFriendly | messageString notNil ifTrue:[
		listSpec := builder pluggableListSpec new.
		listSpec 
			model: self;
			list: #contextStackList; 
			getIndex: #contextStackIndex; 
			setIndex: #debugAt:; 
			frame: (0@0.2 corner: 1@1).
		windowSpec children add: listSpec.
	] ifFalse:[
		textSpec := builder pluggableTextSpec new.
		textSpec 
			model: self;
			getText: #preDebugMessageString; 
			setText: nil; 
			selection: nil; 
			menu: #debugProceedMenu:;
			frame: (0@0.2corner: 1@1).
		windowSpec children add: textSpec.
	].

	^windowSpec