convertOctober2000: varDict using: smartRefStrm
	"ar 10/25/2000: This method is used to convert OLD MorphicEvents into new ones."
	"These are going away #('type' 'cursorPoint' 'buttons' 'keyValue' 'sourceHand').  Possibly store their info in another variable?"
	| type cursorPoint buttons keyValue sourceHand |
	type _ varDict at: 'type'.
	cursorPoint _ varDict at: 'cursorPoint'.
	buttons _ varDict at: 'buttons'.
	keyValue _ varDict at: 'keyValue'.
	sourceHand _ varDict at: 'sourceHand'.
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
	"All others will be handled there"
	^MorphicUnknownEvent new