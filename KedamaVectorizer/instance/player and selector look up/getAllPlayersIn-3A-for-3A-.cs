getAllPlayersIn: aMessageNode for: obj

	| aCollection |
	aCollection _ OrderedCollection new.
	self getPlayersMessage: aMessageNode for: obj into: aCollection.
	^ aCollection.
