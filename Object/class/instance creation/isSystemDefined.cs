isSystemDefined
	"Answer whether the receiver is a system-defined class or a unique-instance user subclass"

	^ self name endsWithDigit not