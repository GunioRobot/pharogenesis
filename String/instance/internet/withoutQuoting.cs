withoutQuoting
	"remove the initial and final quote marks, if present"
	"'''h''' withoutQuoting"
	| quote |
	self size < 2 ifTrue: [ ^self ].
	quote _ self first.
	(quote = $' or: [ quote = $" ])
		ifTrue: [ ^self copyFrom: 2 to: self size - 1 ]
		ifFalse: [ ^self ].