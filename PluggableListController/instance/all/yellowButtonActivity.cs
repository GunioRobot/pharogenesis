yellowButtonActivity
	"Invoke the model's menu."

	| menu |
	menu _ view getMenu.
	menu == nil ifFalse: [menu invokeOn: model].