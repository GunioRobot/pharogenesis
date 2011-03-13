convertObsolete: anEvent
	"ar 10/25/2000: This method is used to convert OLD MorphicEvents into new ones."
	| type cursorPoint buttons keyValue sourceHand |
	type _ anEvent type.
	cursorPoint _ anEvent cursorPoint.
	buttons _ anEvent buttons.
	keyValue _ anEvent keyValue.
	sourceHand _ anEvent hand.
	type == #mouseMove ifTrue:[
		^MouseMoveEvent new
			setType: #mouseMove 
			startPoint: cursorPoint
			endPoint: cursorPoint
			trail: #() 
			buttons: buttons 
			hand: sourceHand 
			stamp: nil].
	(type == #mouseDown) | (type == #mouseUp) ifTrue:[
			^MouseButtonEvent new
				setType: type
				position: cursorPoint
				which: 0
				buttons: buttons
				hand: sourceHand
				stamp: nil].
	(type == #keystroke) | (type == #keyDown) | (type == #keyUp) ifTrue:[
		^KeyboardEvent new
			setType: type
			buttons: buttons
			position: cursorPoint
			keyValue: keyValue
			hand: sourceHand
			stamp: nil].
	^nil