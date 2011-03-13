setQuery: queryString initialAnswer: initialAnswer answerHeight: answerHeight

	response _ initialAnswer.
	done _ false.
	self removeAllMorphs.
	self extent: 200@70.
	self addQuery: queryString.
	self width: (self width max: self firstSubmorph width + (2 * borderWidth)).
	self addLine.
	textPane _ PluggableTextMorph on: self
		text: #response
		accept: #response:
		readSelection: #selectionInterval
		menu: #codePaneMenu:shifted:.
	textPane hasUnacceptedEdits: true.
	textPane retractableOrNot.
	textPane extent: self innerBounds width@answerHeight.
	textPane position: self innerBounds left@self lastSubmorph bottom.
	self addMorphBack: textPane.
	self addLine.
	self addButtonRow.
	self height: (self height max: (self lastSubmorph bottom - self top) + borderWidth).
