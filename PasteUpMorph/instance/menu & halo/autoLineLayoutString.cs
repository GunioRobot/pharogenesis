autoLineLayoutString
	"Answer the string to be shown in a menu to represent the auto-line-layout status"

	^ self autoLineLayout
		ifTrue:
			['<on>auto-line-layout']
		ifFalse:
			['<off>auto-line-layout']
