yellowButtonActivity
	"Invoke the model's menu.  This is option-click, NOT the normal button press."
	| menu |
	menu _ view getMenu: false.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [self terminateAndInitializeAround: [menu invokeOn: model]].
