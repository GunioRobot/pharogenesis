setQuery: queryString initialAnswer: initialAnswer answerHeight: answerHeight acceptOnCR: acceptBoolean
	| query frame topOffset accept cancel buttonAreaHeight |
	response _ initialAnswer.
	done _ false.
	self removeAllMorphs.

	self layoutPolicy: ProportionalLayout new.

	query _ TextMorph new contents: queryString.
	query setNameTo: 'query'.
	query lock.
		frame _ LayoutFrame new.
		frame topFraction: 0.0; topOffset: 2.
		frame leftFraction: 0.5; leftOffset: (query width // 2) negated.
	query layoutFrame: frame.
	self addMorph: query.
	topOffset _ query height + 4.

	accept _ SimpleButtonMorph new target: self; color: Color veryLightGray.
	accept label: 'Accept(s)'; actionSelector: #accept.
	accept setNameTo: 'accept'.
		frame _ LayoutFrame new.
		frame rightFraction: 0.5; rightOffset: -10; bottomFraction: 1.0; bottomOffset: -2.
	accept layoutFrame: frame.
	self addMorph: accept.

	cancel _ SimpleButtonMorph new target: self; color: Color veryLightGray.
	cancel label: 'Cancel(l)'; actionSelector: #cancel.
	cancel setNameTo: 'cancel'.
		frame _ LayoutFrame new.
		frame leftFraction: 0.5; leftOffset: 10; bottomFraction: 1.0; bottomOffset: -2.
	cancel layoutFrame: frame.
	self addMorph: cancel.
	buttonAreaHeight _ (accept height max: cancel height) + 4.

	textPane _ PluggableTextMorph on: self
		text: #response
		accept: #response:
		readSelection: #selectionInterval
		menu: #codePaneMenu:shifted:.
	textPane hResizing: #spaceFill; vResizing: #spaceFill.
	textPane borderWidth: 2.
	textPane hasUnacceptedEdits: true.
	textPane acceptOnCR: acceptBoolean.
	textPane setNameTo: 'textPane'.
		frame _ LayoutFrame new.
		frame leftFraction: 0.0; rightFraction: 1.0; topFraction: 0.0; topOffset: topOffset; bottomFraction: 1.0; bottomOffset: buttonAreaHeight negated.
	textPane layoutFrame: frame.
	self addMorph: textPane.

	self extent: (200 max: query width) + 4 @ (topOffset + answerHeight + 4 + buttonAreaHeight).
