fenceEnabledString
	"Answer the string to be shown in a menu to represent the  
	fence enabled status"
	^ (self fenceEnabled
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, 'fence enabled' translated