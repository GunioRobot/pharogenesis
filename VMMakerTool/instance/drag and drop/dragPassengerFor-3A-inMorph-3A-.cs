dragPassengerFor: item inMorph: dragSource 
	(dragSource isKindOf: PluggableListMorph)
		ifFalse: [^item].
	^item contents