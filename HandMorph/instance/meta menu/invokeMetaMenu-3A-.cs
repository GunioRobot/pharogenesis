invokeMetaMenu: evt
	"Invoke the meta menu. If the hand is over the background, the world menu is presented. If it is over a morph, a menu of operations for that morph is presented. Each menu entry contains a string to be presented in the menu and a selector. If the selector takes an argument, the mouse-down event that invoked the menu is passed as an argument. This lets the command know which hand invoked it in  order to do things like attaching the result of the command to that hand."
	"Shortcut: If the shift key is pressed, the user is given a chance to select a submorph on which to operate."

	| menu |
	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	targetOffset _ menuTargetOffset _ self position.
	argument _ self argumentOrNil.
	argument == nil
		ifTrue: [
			menu _ self buildWorldMenu.
			menu addTitle: 'World']
		ifFalse: [
			menu _ self buildMorphMenuFor: argument.
			menu addTitle: argument class name].
	self invokeMenu: menu event: evt.
