addToFormatter: formatter
	| httpEquiv |
	httpEquiv _ self getAttribute: 'http-equiv'.
	httpEquiv ifNil: [ ^self ].
	httpEquiv asLowercase = 'refresh' ifTrue: [
		formatter addString: '{refresh: ', (self getAttribute:  'content' default: ''), '}' ].