dismissViaHalo
	"Dismiss the receiver (and its referent), unless it resists"

	self resistsRemoval ifTrue:
		[(PopUpMenu confirm: 'Really throw this flap away' trueChoice: 'Yes' falseChoice: 'Um, no, let me reconsider') ifFalse: [^ self]].

	referent delete.
	self delete