buildPluggableText: aSpec
	| widget |
	widget := PluggableTextMorphPlus on: aSpec model
				text: aSpec getText 
				accept: aSpec setText
				readSelection: aSpec selection 
				menu: aSpec menu.
	self register: widget id: aSpec name.
	widget getColorSelector: aSpec color.
	self setFrame: aSpec frame in: widget.
	parent ifNotNil:[self add: widget to: parent].
	panes ifNotNil:[
		aSpec getText ifNotNil:[panes add: aSpec getText].
	].
	^widget