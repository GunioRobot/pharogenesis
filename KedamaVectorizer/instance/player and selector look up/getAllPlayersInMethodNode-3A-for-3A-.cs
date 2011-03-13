getAllPlayersInMethodNode: aMethodNode for: obj

	| aCollection |
	aCollection _ OrderedCollection new.
	aMethodNode block statements do: [:stmt |
		(stmt isMemberOf: MessageNode) ifTrue: [
			self getPlayersMessage: stmt for: obj into: aCollection.
		].
		(stmt isMemberOf: BlockNode) ifTrue: [
			self getPlayersBlock: stmt for: obj into: aCollection.
		].
	].
	^ aCollection.
