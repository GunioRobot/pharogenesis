listSelectionAt: aNumber put: aBoolean
	| item |
	item _ self items at: aNumber.
	aBoolean
		ifTrue: [self kept add: item ]
		ifFalse: [self kept remove: item ifAbsent: []]