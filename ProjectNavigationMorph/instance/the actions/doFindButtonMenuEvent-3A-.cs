doFindButtonMenuEvent: evt

	| menu selection |

	menu _ CustomMenu new.
	menu 
		add: 'find a project' translated action: [self findAProjectSimple];
		add: 'find a project (more places)' translated action: [self findAProject];
		add: 'find any file' translated action: [self findAnything];
		add: 'search the SuperSwiki' translated action: [self findSomethingOnSuperSwiki].

	selection _ menu build startUpCenteredWithCaption: 'Find options' translated.
	selection ifNil: [^self].
	selection value.

