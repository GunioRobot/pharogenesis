doFindButtonMenuEvent: evt

	| menu selection |

	menu _ CustomMenu new.
	menu 
		add: 'find a project' action: [self findAProject];
		add: 'find any file' action: [self findAnything];
		add: 'search the SuperSwiki' action: [self findSomethingOnSuperSwiki].

	selection _ menu build startUpCenteredWithCaption: 'Find options'.
	selection ifNil: [^self].
	selection value.

