defaultBorderWidth
	"answer the default border width for the receiver"
	^ Preferences alternativeWindowLook
		ifTrue: [2]
		ifFalse: [1]