defaultBorderColor
	"answer the default border color/fill style for the receiver"
	^ (Preferences menuSelectionColor ifNil: [Color blue]) twiceDarker alpha: 0.75