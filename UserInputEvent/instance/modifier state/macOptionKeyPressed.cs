macOptionKeyPressed
	"Answer whether the option key on the Macintosh keyboard was being held down when this event occurred. Macintosh specific."

	Preferences macOptionKeyAllowed ifFalse: [self notifyWithLabel: 'Portability note:
MorphicEvent>>macOptionKeyPressed is not portable.
Please use MorphicEvent>>yellowButtonPressed instead!'].
	^ buttons anyMask: 32