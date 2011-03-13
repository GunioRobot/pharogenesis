swapControlAndAltKeys: aBoolean
	"InputEventSensor swapControlAndAltKeys: true"

	Preferences setPreference: #swapControlAndAltKeys toValue: aBoolean.
	self installKeyDecodeTable