duplicateControlAndAltKeys: aBoolean
	"InputEventSensor duplicateControlAndAltKeys: true"

	Preferences setPreference: #duplicateControlAndAltKeys toValue: aBoolean.
	self installKeyDecodeTable
