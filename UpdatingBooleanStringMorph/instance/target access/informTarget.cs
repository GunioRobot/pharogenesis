informTarget
	"Determine a value by evaluating my readout, and send that value to my target"

	| newValue |
	(target notNil and: [putSelector notNil]) 
		ifTrue: 
			[newValue := self valueFromContents.
			newValue ifNotNil: 
					[target 
						perform: putSelector
						with: getSelector
						with: newValue.
					target isMorph ifTrue: [target changed]].
			self growable 
				ifTrue: 
					[self
						readFromTarget;
						fitContents.
					owner updateLiteralLabel]]