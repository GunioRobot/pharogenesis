at: key ifAbsent: aBlock 

	| index assoc |
	index _ self findElementOrNil: key.
	assoc _ array at: index.
	nil == assoc ifTrue: [ ^ aBlock value ].
	^ assoc value