doPublishButtonMenuEvent: evt

	| menu selection |

	menu _ CustomMenu new.
	menu 
		add: 'Publish' translated action: [self publishProject];
		add: 'Publish As...' translated action: [self publishProjectAs];
		add: 'Publish to Different Server' translated action: [self publishDifferent];
		add: 'edit project info' translated action: [self editProjectInfo].
	selection _ menu build startUpCenteredWithCaption: 'Publish options' translated.
	selection ifNil: [^self].
	selection value.

