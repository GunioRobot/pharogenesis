autoProceed
	| someView |
	someView _ self dependents first.
	self proceed: someView topView controller