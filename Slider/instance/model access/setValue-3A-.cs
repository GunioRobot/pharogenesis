setValue: newValue
	"Called internally for propagation to model"
	self value: newValue.
	self use: setValueSelector orMakeModelSelectorFor: 'Value:'
		in: [:sel | setValueSelector := sel.  model perform: sel with: value]