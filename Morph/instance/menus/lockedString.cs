lockedString
	"Answer the string to be shown in a menu to represent the 'locked' status"

	^ self isLocked
		ifTrue:
			['<on>locked']
		ifFalse:
			['<off>locked']