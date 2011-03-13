useGlobalFlapsString
	"Answer the string to be shown in a menu to represent the use-global-flaps status"

	^ (Preferences valueOfFlag: #useGlobalFlaps)
			ifTrue: ['<yes>use global flaps']
			ifFalse: ['<no>use global flaps']