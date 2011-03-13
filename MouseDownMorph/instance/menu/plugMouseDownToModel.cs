plugMouseDownToModel
	mouseDownSelector _ (self knownName , 'MouseDown:event:') asSymbol.
	model class compile: (

'&nameMouseDown: trueOrFalse event: event
	"A mouseDown event has occurred.
	Add code to handle it here below..."'

			copyReplaceAll: '&name' with: self knownName)
		classified: 'input events' notifying: nil