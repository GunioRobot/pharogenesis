hasNoLayoutString
	^self layoutPolicy == nil
		ifTrue:['<on>no layout']
		ifFalse:['<off>no layout'].