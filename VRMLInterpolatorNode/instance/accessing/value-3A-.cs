value: newValue
	value _ newValue.
	self triggerEvent: #'value_changed' with: newValue.