defaultBorderColor
	"answer the default border color/fill style for the receiver"
	^ Preferences alternativeWindowLook
		ifTrue: [#raised]
		ifFalse: [Color black]