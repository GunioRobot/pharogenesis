roundedCornersString
	"Answer the string to put in a menu that will invite the user to switch to the opposite  corner-rounding mode"
	^ self cornerStyle  == #rounded
		ifTrue:
			['stop rounding corners']
		ifFalse:
			['start rounding corners']
			