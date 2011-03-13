unshiftedYellowButtonActivity
	"Invoke the model's other menu.  Just do what the controller would have done."

	| menu |
	menu _ self contextStackMenu: (CustomMenu new) shifted: false.
	menu == nil
		ifTrue: [Sensor waitNoButton]
		ifFalse: [menu invokeOn: self].
