dispatchOn: anInteger in: selectorArray
	"Simulate a case statement via selector table lookup.
	The given integer must be between 0 and selectorArray size-1, inclusive.
	For speed, no range test is done, since it is done by the at: operation."

	"assert: (anInteger >= 0) | (anInteger < selectorArray size)"
"
Transcript cr; show: anInteger hex , '  ' , (selectorArray at: (anInteger + 1)).
Sensor waitButton.
Sensor yellowButtonPressed ifTrue: [self halt].
"
	self perform: (selectorArray at: (anInteger + 1)).