handlesMouseDown: evt
	"Prevent stray clicks from picking up the whole game in MVC."

	^ Smalltalk isMorphic not or: [evt yellowButtonPressed]