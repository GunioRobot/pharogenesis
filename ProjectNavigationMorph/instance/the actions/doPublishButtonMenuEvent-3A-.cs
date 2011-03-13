doPublishButtonMenuEvent: evt

	| menu selection |

	menu _ CustomMenu new.
	menu 
		add: 'publish normally' action: [self publishProject];
		add: 'publish to different server' action: [self publishDifferent];
		add: 'edit project info' action: [self editProjectInfo].
	selection _ menu build startUpCenteredWithCaption: 'Publish options'.
	selection ifNil: [^self].
	selection value.

