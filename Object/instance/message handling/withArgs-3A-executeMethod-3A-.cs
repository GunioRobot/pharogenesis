withArgs: argArray executeMethod: compiledMethod
	"Execute compiledMethod against the receiver and args in argArray"

	| selector |
	<primitive: 188>
	selector _ Symbol new.
	self class addSelectorSilently: selector withMethod: compiledMethod.
	^ [self perform: selector withArguments: argArray]
		ensure: [self class basicRemoveSelector: selector]