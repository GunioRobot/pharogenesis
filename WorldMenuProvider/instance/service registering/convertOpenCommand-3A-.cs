convertOpenCommand: array 
	| description |
	description := array size > 2 
				ifTrue: [array third]
				ifFalse: ['none available'].
	^ServiceAction 
		id: array first asSymbol
		text: array first
		button: array first
		description: description
		action: [array second first perform: array second second]