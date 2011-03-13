yellowButtonActivity
	"Invoke the model's menu.  This is option-click, NOT the normal button press."
	| menu |
	menu := view getMenu: false.
	menu == nil
		ifTrue: [sensor waitNoButton]
		ifFalse: [self terminateAndInitializeAround: [menu invokeOn: model]].
