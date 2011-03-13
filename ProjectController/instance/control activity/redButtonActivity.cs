redButtonActivity
	| index |
	view isCollapsed ifTrue: [^ super redButtonActivity].
	(view insetDisplayBox containsPoint: Sensor cursorPoint)
		ifFalse: [^ super redButtonActivity].
	index _ (PopUpMenu labelArray: #('enter' 'jump to project...') lines: #()) 
		startUpCenteredWithCaption: nil.
	index = 0 ifTrue: [^ self].

	"save size on enter for thumbnail on exit"
	model setViewSize: view insetDisplayBox extent.
	index = 1 ifTrue: [^ model enter: false].
	index = 2 ifTrue: [Project jumpToProject. ^ self].
