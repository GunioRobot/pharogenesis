dismissViaHalo
	| choice |
	project ifNil:[^self delete]. "no current project"
	choice := (PopUpMenu labelArray:{
		'yes - delete the window and the project' translated.
		'no - delete the window only' translated
	}) startUpWithCaption: ('Do you really want to delete {1}
and all its content?' translated format: {project name printString}).
	choice = 1 ifTrue:[^self expungeProject].
	choice = 2 ifTrue:[^self delete].