doYellowButtonPress: evt

	| menu |

	menu _ CustomMenu new.
	menu 
		add: 'Go to top of document'				action: [self jumpToDocumentTop];
		add: 'Move selection to top of page'		action: [self scrollSelectionToTop];
		add: 'Add column break'					action: [self addColumnBreak];
		add: 'Define as jump start'				action: [self addJumpBeginning];
		add: 'Define as jump end'				action: [self addJumpEnd].

	((menu build startUpCenteredWithCaption: 'Text navigation options') ifNil: [^self]) value.
