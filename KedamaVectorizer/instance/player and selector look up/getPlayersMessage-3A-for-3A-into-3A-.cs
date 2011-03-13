getPlayersMessage: aMessageNode for: obj into: aCollection

	| thisPlayer |
	((Array with: aMessageNode receiver), aMessageNode arguments) do: [:stmt |
		(stmt isMemberOf: MessageNode) ifTrue: [
			self getPlayersMessage: stmt for: obj into: aCollection.
		].
		(stmt isMemberOf: BlockNode) ifTrue: [
			self getPlayersBlock: stmt for: obj into: aCollection..
		].
		(stmt isMemberOf: VariableNode) ifTrue: [
			thisPlayer _ Compiler evaluate: stmt name for: obj logged: false.
			(thisPlayer isKindOf: Player) ifTrue: [aCollection add: stmt].
		].
	].
