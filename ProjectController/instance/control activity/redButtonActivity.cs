redButtonActivity
	| index |
	view isCollapsed ifTrue: [^ super redButtonActivity].
	(view insetDisplayBox containsPoint: Sensor cursorPoint)
		ifFalse: [^ super redButtonActivity].
	index _ (PopUpMenu labelArray: #('enter') lines: #()) 
		startUpCenteredWithCaption: nil.
	index = 1 ifTrue: ["Save size on enter for thumbnail on exit"
					model setViewSize: view insetDisplayBox extent.
					^ model enter]