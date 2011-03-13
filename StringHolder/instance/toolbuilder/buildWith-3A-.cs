buildWith: builder
	| windowSpec textSpec |
	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'Workspace'.
	windowSpec children: OrderedCollection new.
	textSpec := builder pluggableTextSpec new.
	textSpec 
		model: self;
		getText: #contents; 
		setText: #acceptContents:; 
		selection: nil; 
		menu: #codePaneMenu:shifted:;
		frame: (0@0corner: 1@1).
	windowSpec children add: textSpec.

	^builder build: windowSpec