dragPassengerFor: item inMorph: dragSource
	"Create a information string representing the message to drag (and display while dragging)"

	| msgID |
	(dragSource isKindOf: PluggableListMorph) ifFalse: [^item].

	dragSource getListSelector == #tocEntryList
		ifTrue: [ msgID _ self msgIDFromTOCEntry: item contents.
				^ msgID printString, ' ', (mailDB getMessage: msgID) from].

	"Give them nil if they try to drag a category for instance"
	^nil