mouseDown: evt
	"Quick hack: use old-fashioned menu."

	| menu selection |
	menu _ CustomMenu new
		add: 'enter' action: #enter;
		add: 'jump to project...' action: #jumpToProject.
	selection _ menu startUp: #enter.
	selection = #enter ifTrue: [^ self enter].
	selection = #jumpToProject ifTrue: [Project jumpToProject. ^ self].

