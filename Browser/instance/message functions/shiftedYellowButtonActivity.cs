shiftedYellowButtonActivity
	"Invoke the model's other menu.  Just do what the controller would have done."

	| menu |
	menu _ self messageListMenu: (CustomMenu new) shifted: true.
	menu == nil
		ifTrue: [Sensor waitNoButton]
		ifFalse: [menu invokeOn: self].
