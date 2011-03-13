computeSelfSendersFromInheritedSelfSenders: inheritedCollection localSelfSenders: localCollection
	"Compute the set of all self-senders from the set of inherited self-senders and the set of local self-senders."

	| result mDict |
	mDict _ self methodDict.
	result _ IdentitySet new: inheritedCollection size + localCollection size.
	"This if-statement is just a performance optimization. 
	Both branches are semantically equivalent."
	inheritedCollection size > mDict size ifTrue: [
		result addAll: inheritedCollection.
		mDict keysDo: [:each | result remove: each ifAbsent: []].
	] ifFalse: [
		inheritedCollection do: [:each | (mDict includesKey: each) ifFalse: [result add: each]].
	].
	result addAll: localCollection.
	^ result.