addCheckBoxButtonToFormatter: formatter
	| name formData checked button buttonInput |

	"dig up relevant attributes"
	name _ self getAttribute: 'name'.
	name ifNil: [ ^self ].
	value _ self getAttribute: 'value'.
	value ifNil: [ ^value ].
	
	formData _ formatter currentFormData.
	formData ifNil:  [ ^self ].

	checked _ (self getAttribute: 'checked') isNil not.

	"set up the form input"
	buttonInput _ ToggleButtonInput name: name value: value checkedByDefault: checked.
	formData addInput: buttonInput.

	"create the actual button"
	button _ UpdatingThreePhaseButtonMorph checkBox.
	button target: buttonInput;
		getSelector: #pressed;
		actionSelector: #toggle.
	buttonInput button: button.
	formatter addMorph: button.


