asCharacter
	"Answer the Character whose value is the receiver."

	self > 255
		ifTrue: [^ MultiCharacter value: self]
		ifFalse: [^ Character value: self]
