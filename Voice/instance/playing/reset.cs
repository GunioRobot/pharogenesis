reset
	"Reset the state of the receiver."
	sound notNil ifTrue: [sound done: true. sound _ nil]