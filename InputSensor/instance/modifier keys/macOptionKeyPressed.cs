macOptionKeyPressed
	"Answer whether the option key on the Macintosh keyboard is being held down. Macintosh specific."

	Preferences macOptionKeyAllowed ifFalse: [self notifyWithLabel: 'Portability note:
InputSensor>>macOptionKeyPressed is not portable.
Please use InputSensor>>yellowButtonPressed instead!'].
	^ self primMouseButtons anyMask: 32