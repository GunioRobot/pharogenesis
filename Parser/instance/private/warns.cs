warns
	"self new warns"
	"return whether the parser will ask the user for correction"
	
	"Implementation note: this is implemented as a lazy accessor to be robust against
	missed class initialization"
	
	Warns ifNil: [Warns := false].
	^ Warns