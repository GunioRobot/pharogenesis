uniqueNameForReferenceFrom: proposedName
	"Answer a satisfactory symbol, similar to the proposedName but obeying the rules, to represent the receiver"

	| aName nameSym stem okay |
	proposedName = self uniqueNameForReferenceOrNil 
		ifTrue: [^ proposedName].  "No change"

	stem _ proposedName select: [:ch | ch isLetter or: [ch isDigit]].
	stem size == 0 ifTrue: [stem _ 'A'].
	stem first isLetter ifFalse:
		[stem _ 'A', stem].
	stem _ stem capitalized.
	aName _ Utilities keyLike: stem satisfying:
		[:jinaLake |
			nameSym _ jinaLake asSymbol.
			okay _ true.
			self class scopeHas: nameSym ifTrue: [:x | okay _ false "don't use it"].
			okay].
	^ aName asSymbol