addButtonWithLabel: label
	| model |
	model _ OBButtonModel withLabel: label inBar: self.
	models add: model.
	actions at: model put: nil