contents: c notifying: k
	"later, spruce this up so that it can accept input such as new method source"
	| info |
	(info _ self userSlotInformation)
		ifNotNil:
			[info documentation: c.
			^ true].
	Beeper beep.
	^ false