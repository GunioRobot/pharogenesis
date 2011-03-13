send: selector to: rcvr with: args super: superFlag 
	"Simulate the action of sending a message with selector, selector, and 
	arguments, args, to receiver. The argument, superFlag, tells whether the 
	receiver of the message was specified with 'super' in the source method."

	| class meth val |
	class _ 
		superFlag
			ifTrue: [(self method literalAt: self method numLiterals) value superclass]
			ifFalse: [rcvr class].
	[class == nil]
		whileFalse: 
			[(class includesSelector: selector)
				ifTrue: 
					[meth _ class compiledMethodAt: selector.
					val _ 
						self tryPrimitiveFor: meth
							receiver: rcvr
							args: args.
					val == #simulatorFail ifFalse: [^val].
					(selector == #doesNotUnderstand: and: [class == Object]) ifTrue:
						[ ^ self error: 'Simulated message ' , (args at: 1) selector , ' not understood' ].
					^self
						activateMethod: meth
						withArgs: args
						receiver: rcvr
						class: class].
			class _ class superclass].
	^self send: #doesNotUnderstand:
		to: rcvr
		with: (Array with: (Message selector: selector arguments: args))
		super: superFlag