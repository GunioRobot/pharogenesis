sourceCodeAt: selector
	| code method dict |
	method _ methodDict at: selector.
	Sensor leftShiftDown
		ifTrue: [code _ (self decompilerClass new
						decompile: selector
						in: self
						method: method) decompileString]
		ifFalse: 
			[code _ method getSource.
			code == nil
				ifTrue: 
					[code _ (self decompilerClass new
									decompile: selector
									in: self
									method: method) decompileString]].
	^code