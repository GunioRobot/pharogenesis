step
	| newBoolean |
	super step.
	state == #pressed ifTrue: [^ self].
	newBoolean _ target perform: getSelector.
	newBoolean == self isOn
		ifFalse:
			[self state: (newBoolean == true ifTrue: [#on] ifFalse: [#off])]