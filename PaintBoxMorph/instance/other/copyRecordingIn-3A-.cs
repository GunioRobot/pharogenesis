copyRecordingIn: dict
	"Overridden to copy the stamps holder."

	| new |
	new _ super copyRecordingIn: dict.
	new stampHolder: stampHolder copy.
	new colorMemory: (colorMemory copyRecordingIn: dict).
	^ new