swapControlAndAltKeys: aBoolean
	"InputSensor swapControlAndAltKeys: true"

	Preferences setPreference: #swapControlAndAltKeys toValue: aBoolean.
	self installKeyDecodeTable