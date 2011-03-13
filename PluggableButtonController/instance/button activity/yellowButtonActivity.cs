yellowButtonActivity
	"Invoke the model's menu.  This is option-click, NOT the normal button press."

	| menu |
	menu _ view getMenu.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [self controlTerminate.
				menu invokeOn: model.
				self controlInitialize].
