accountWithName: aName
	"Look up an account by name. Return nil if missing."

	^self accounts values detect: [:a | a name = aName ] ifNone: [nil]