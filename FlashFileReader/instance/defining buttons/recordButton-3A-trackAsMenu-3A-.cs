recordButton: id trackAsMenu: aBoolean
	"Track the button with the given ID as a menu (in contrast to a push) button. Push buttons capture the mouse until the button is released. Menu buttons don't.
	Note: If defined for a button, this method will be called prior to any other #recordButton: methods."