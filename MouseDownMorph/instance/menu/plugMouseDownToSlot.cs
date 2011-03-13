plugMouseDownToSlot
	| varName |
	mouseDownSelector _ (self knownName , 'MouseDown:event:') asSymbol.
	varName _ self knownName , 'MouseDown'.
	model class addSlotNamed: varName.
	model class compile: (

'&name: trueOrFalse event: event
	"A mouseDown event has occurred.
	Add code to handle it here below..."
	&name _ trueOrFalse.'

			copyReplaceAll: '&name' with: varName)
		classified: 'input events' notifying: nil