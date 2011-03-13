showInOpenedState

	| answer |
	answer _ self valueOfProperty: #showInOpenedState ifAbsent: [false].
	self removeProperty: #showInOpenedState.
	^answer