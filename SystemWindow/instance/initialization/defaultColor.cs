defaultColor
	"answer the default color/fill style for the receiver"
	^ Preferences alternativeWindowLook
		ifTrue: [Color white]
		ifFalse: [Color black]