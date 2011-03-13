removeSelf
	"Nil the receiver pointer and answer its former value."

	| tempSelf |
	tempSelf _ receiver.
	receiver _ nil.
	^tempSelf