send: selector super: superFlag numArgs: numArgs
	"Simulate the action of bytecodes that send a message with selector, 
	selector. The argument, superFlag, tells whether the receiver of the 
	message was specified with 'super' in the source method. The arguments 
	of the message are found in the top numArgs locations on the stack and 
	the receiver just below them."

	| receiver arguments answer |
	arguments _ Array new: numArgs.
	numArgs to: 1 by: -1 do: [ :i | arguments at: i put: self pop].
	receiver _ self pop.
	(selector == #halt or: [selector == #halt:]) ifTrue:
		[self error: 'Cant simulate halt.  Proceed to bypass it.'.
		self push: nil. ^self].
	selector == #doPrimitive:receiver:args:
		ifTrue: [answer _ receiver 
					doPrimitive: (arguments at: 1)
					receiver: (arguments at: 2)
					args: (arguments at: 3).
				self push: answer.
				^self].
	^self send: selector to: receiver with: arguments super: superFlag