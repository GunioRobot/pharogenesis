duplicateControlAndAltKeysChanged
	"The Preference for duplicateControlAndAltKeys has changed."
	(Preferences
		valueOfFlag: #swapControlAndAltKeys
		ifAbsent: [false]) ifTrue: [
			self inform: 'Resetting swapControlAndAltKeys preference'.
			(Preferences preferenceAt: #swapControlAndAltKeys) rawValue: false.
		].
	self installKeyDecodeTable.
