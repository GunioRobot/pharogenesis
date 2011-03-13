redButtonActivity
	| index |
	view isCollapsed ifTrue: [^ super redButtonActivity].
	(view insetDisplayBox containsPoint: Sensor cursorPoint)
		ifFalse: [^ super redButtonActivity].
	index := (UIManager default chooseFrom: #('enter' 'jump to project...') lines: #()).
	index = 0 ifTrue: [^ self].

	"save size on enter for thumbnail on exit"
	model setViewSize: view insetDisplayBox extent.
	index = 1 ifTrue: [^ model enter: false revert: false saveForRevert: false].
	index = 2 ifTrue: [Project jumpToProject. ^ self].
