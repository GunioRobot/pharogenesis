addRadioButtonToFormatter: formatter
	| name formData checked buttonSet button buttonInput |

	"dig up relevant attributes"
	name _ self getAttribute: 'name'.
	name ifNil: [ ^self ].
	value _ self getAttribute: 'value'.
	value ifNil: [ ^value ].
	
	formData _ formatter currentFormData.
	formData ifNil:  [ ^self ].

	checked _ self getAttribute: 'checked'.


	"find or create the set of buttons with our same name"
	buttonSet _ formData inputs detect: [ :i | i isRadioButtonSetInput and: [ i name = name ] ] ifNone: [ nil ].
	buttonSet ifNil: [ 
		"create a new button set"
		buttonSet _ RadioButtonSetInput name: name.
		formData addInput: buttonSet. ].

	"set up the form input"
	buttonInput _ RadioButtonInput  inputSet: buttonSet value: value.
	buttonSet addInput: buttonInput.
	checked ifNotNil: [
		buttonSet  defaultButton: buttonInput ].

	"create the actual button"
	button _ UpdatingThreePhaseButtonMorph radioButton.
	button target: buttonInput;
		getSelector: #pressed;
		actionSelector: #toggle.
	buttonInput button: button.
	formatter addMorph: button.


