redButtonActivity
	| index |
	view isCollapsed ifTrue: [^ super redButtonActivity].
	(view insetDisplayBox containsPoint: Sensor cursorPoint)
		ifFalse: [^ super redButtonActivity].
	index _ (PopUpMenu labelArray: #('enter' 'fileOut') lines: #(1)) 
		startUpCenteredWithCaption: nil.
	index = 1 ifTrue: [^ model enter].
	index = 2 ifTrue: [^ model fileOut].
