doubleClick: event
	| index |
	doubleClickSelector isNil ifTrue: [^super doubleClick: event].
	index _ self rowAtLocation: event position.
	index = 0 ifTrue: [^super doubleClick: event].
	"selectedMorph ifNil: [self setSelectedMorph: aMorph]."
	^ self model perform: doubleClickSelector