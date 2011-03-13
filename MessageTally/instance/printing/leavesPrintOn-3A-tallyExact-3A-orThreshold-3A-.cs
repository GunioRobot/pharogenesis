leavesPrintOn: aStream tallyExact: isExact orThreshold: threshold
	| dict |
	dict _ IdentityDictionary new: 100.
	self leavesInto: dict fromSender: nil.
	isExact ifTrue: 
		[dict asSortedCollection
			do: [:node |
				node printOn: aStream total: tally tallyExact: isExact.
				node printSenderCountsOn: aStream]]
		ifFalse:
		[(dict asOrderedCollection
				select: [:node | node tally > threshold])
			asSortedCollection
			do: [:node |
				node printOn: aStream total: tally tallyExact: isExact]]