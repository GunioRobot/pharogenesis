swapMouseButtons: aBoolean
	"InputEventSensor swapMouseButtons: true"

	Preferences setPreference: #swapMouseButtons toValue: aBoolean.
	self installMouseDecodeTable.