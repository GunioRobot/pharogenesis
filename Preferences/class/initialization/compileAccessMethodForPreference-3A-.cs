compileAccessMethodForPreference: aPreference
	"Compile an accessor method for the given preference"

	self class compileSilently: (aPreference name, '
	^ self valueOfFlag: #', aPreference name, ' ifAbsent: [', aPreference defaultValue storeString, ']') classified: 'standard queries'