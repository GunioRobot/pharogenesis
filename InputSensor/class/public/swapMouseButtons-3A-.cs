swapMouseButtons: aBoolean
	"InputSensor swapMouseButtons: true"

	Preferences setPreference: #swapMouseButtons toValue: aBoolean.
	self installMouseDecodeTable.