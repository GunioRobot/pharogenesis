addProjectTarget
	| player fill |
	player _ self flashPlayer.
	player ifNil:[^self inform:'I must be in a flash player for this'].
	(submorphs size = 1 and:[submorphs first isFlashShape])
		ifFalse:[^self inform:'Cannot use me as a project target'].
	fill _ submorphs first fillForProjectTarget.
	fill ifNil:[^self inform:'No suitable fill style found'].
	player addFillForProjectTarget: fill.