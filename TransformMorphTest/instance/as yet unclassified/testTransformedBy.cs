testTransformedBy
	"self run: #testTransformedBy"
	"self debug: #testTransformedBy"
	
	| parent child |
	parent _ PasteUpMorph new openInWorld extent: 100@100.
	parent addMorph: (child _ Morph new).
	child heading: 30.
	parent heading: 30.
	self shouldnt: 
			[ActiveHand grabMorph: child.
			ActiveHand position: 10@10 + ActiveHand position.] 
		raise: MessageNotUnderstood