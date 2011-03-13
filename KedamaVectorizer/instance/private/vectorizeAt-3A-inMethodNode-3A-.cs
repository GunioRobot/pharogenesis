vectorizeAt: index inMethodNode: aMethodNode

	| v encoder origReceiverName origReceiver aMessageNode |
	aMessageNode _ aMethodNode block statements at: index.
	(attributes getAttribute: #requireVector of: aMessageNode) ifFalse: [^ self].

	encoder _ aMethodNode encoder.
	encoder autoBind: 'xxxObj'.
	v _ encoder encodeVariable: 'xxxObj' sourceRange: nil ifUnknown: [].
	origReceiver _ attributes getAttribute: #firstNode of: aMessageNode.
	(origReceiver isMemberOf: VariableNode) ifTrue: [
		origReceiverName _ origReceiver name.
	] ifFalse: [
		origReceiverName _ 'self'.
	].

	self replaceRoot: origReceiverName with: v inMessageNode: aMessageNode.
	"self changeSelectorAt: index inMethodNode: aMethodNode."
	self insertTurtleCommandAt: index in: aMethodNode block statements variableNode: v from: encoder firstReceiverName: origReceiverName.

