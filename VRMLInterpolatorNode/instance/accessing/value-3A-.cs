value: newValue
	value _ newValue.
	self trigger: #'value_changed' with: newValue.