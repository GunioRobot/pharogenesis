openInMorphic
	"open an interface for sending a mail message with the given initial 
	text "
	| buttonsList container toField subjectField |
	buttonsList _ self newRow.
	buttonsList wrapCentering: #center; cellPositioning: #leftCenter.
	buttonsList
		addMorphBack: (
			(self 
				buttonWithAction: #submit
				label: 'send later'
				help: 'add this to the queue of messages to be sent')
		);
		addMorphBack: (
			(self 
				buttonWithAction: #sendNow
				label: 'send now'
				help: 'send this message immediately')
		);
		addMorphBack: (
			(self 
				buttonWithAction: #forgetIt
				label: 'forget it'
				help: 'forget about sending this message')
		).
	morphicWindow _ container _ AlignmentMorphBob1 new
		borderWidth: 8;
		borderColor: self borderAndButtonColor;
		color: Color white.

	container 
		addMorphBack: (buttonsList vResizing: #shrinkWrap; minHeight: 25; yourself);
		addMorphBack: ((self simpleString: 'To:') vResizing: #shrinkWrap; minHeight: 18; yourself);
		addMorphBack: ((toField _ PluggableTextMorph
			on: self
			text: #to
			accept: #to:) hResizing: #spaceFill; vResizing: #rigid; height: 50; yourself
		);
		addMorphBack: ((self simpleString: 'Subject:') vResizing: #shrinkWrap; minHeight: 18; yourself);
		addMorphBack: ((subjectField _ PluggableTextMorph
			on: self
			text: #subject
			accept: #subject:) hResizing: #spaceFill; vResizing: #rigid; height: 50; yourself
		);
		addMorphBack: ((self simpleString: 'Message:') vResizing: #shrinkWrap; minHeight: 18; yourself);
		addMorphBack: ((textEditor _ PluggableTextMorph
			on: self
			text: #messageText
			accept: #messageText:) hResizing: #spaceFill; vResizing: #spaceFill; yourself
		).
	textFields _ {toField. subjectField. textEditor}.
	container 
		extent: 300@400;
		openInWorld.