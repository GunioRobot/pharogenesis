getPlayersBlock: aBlockNode for: obj into: aCollection


	| statements |
	statements _ aBlockNode statements.
	statements do: [:stmt |
		(stmt isMemberOf: MessageNode) ifTrue: [
			self getPlayersMessage: stmt for: obj into: aCollection.
		].
		(stmt isMemberOf: BlockNode) ifTrue: [
			self getPlayersBlock: stmt for: obj into: aCollection..
		].
	].
