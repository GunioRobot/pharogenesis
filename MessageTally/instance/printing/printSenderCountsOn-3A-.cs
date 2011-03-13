printSenderCountsOn: aStream
	| mergedSenders mergedNode |
	mergedSenders _ IdentityDictionary new.
	senders do:
		[:node |
		mergedNode _ mergedSenders at: node method ifAbsent: [nil].
		mergedNode == nil
			ifTrue: [mergedSenders at: node method put: node]
			ifFalse: [mergedNode bump: node tally]].
	mergedSenders asSortedCollection do:
		[:node | 
		10 to: node tally printString size by: -1 do: [:i | aStream space].
		node printOn: aStream total: tally tallyExact: true]