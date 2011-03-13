indicateCursorString
	"Answer the string to be shown in a menu to represent the whether-to-indicate-cursor status"

	^ self indicateCursor
		ifTrue:
			['<on>indicate cursor']
		ifFalse:
			['<off>indicate cursor']
