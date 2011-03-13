displayString: aString
	"Display the given string on the Display. Used for testing."

	| s |
	aString isEmpty ifTrue: [^ self].
	aString size > 60
		ifTrue: [s _ aString copyFrom: 1 to: 60]  "limit to 60 characters"
		ifFalse: [s _ aString].

	s displayOn: Display.
