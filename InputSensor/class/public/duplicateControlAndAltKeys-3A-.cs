duplicateControlAndAltKeys: aBoolean
	"InputSensor duplicateControlAndAltKeys: true"

	Preferences setPreference: #duplicateControlAndAltKeys toValue: aBoolean.
	self installKeyDecodeTable
