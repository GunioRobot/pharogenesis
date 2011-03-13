associationAt: key ifAbsent: aBlock 
	"Answer the association with the given key.
	If key is not found, return the result of evaluating aBlock."

	| index assoc |
	index _ self findElementOrNil: key.
	assoc _ array at: index.
	nil == assoc ifTrue: [ ^ aBlock value ].
	^ assoc