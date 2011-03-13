yellowButtonActivity
	"Invoke the model's menu."

	| menu |
	menu _ view getMenu.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [self controlTerminate.
				menu invokeOn: model.
				self controlInitialize].
