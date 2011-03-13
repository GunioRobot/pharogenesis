flush
	"Play all the events in the queue."
	sound notNil ifTrue: [sound done: true; play. sound := nil]