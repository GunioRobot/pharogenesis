fenceEnabledString
	"Answer the string to be shown in a menu to represent the fence enabled status"

	^self fenceEnabled
		ifTrue:
			['<on>fence enabled']
		ifFalse:
			['<off>fence enabled']
