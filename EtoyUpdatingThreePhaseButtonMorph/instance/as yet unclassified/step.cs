step
	| newBoolean |

	state == #pressed ifTrue: [^ self].
	newBoolean _ target perform: getSelector withArguments: arguments.
	newBoolean == self isOn
		ifFalse:
			[self state: (newBoolean ifTrue: [#on] ifFalse: [#off])]
