defaultColor
	"answer the default color/fill style for the receiver"
	^ (Preferences menuSelectionColor ifNil: [Color blue]) alpha: 0.08
