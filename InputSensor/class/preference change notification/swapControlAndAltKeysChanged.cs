swapControlAndAltKeysChanged
	"The Preference for swapControlAndAltKeys has changed."
	(Preferences
		valueOfFlag: #duplicateControlAndAltKeys
		ifAbsent: [false]) ifTrue: [
			self inform: 'Resetting duplicateControlAndAltKeys preference'.
			(Preferences preferenceAt: #duplicateControlAndAltKeys) rawValue: false.
		].
	self installKeyDecodeTable.
