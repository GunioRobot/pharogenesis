summary
	^self hasVersion
		ifTrue: [ self version summary ]
		ifFalse: [ String new ]