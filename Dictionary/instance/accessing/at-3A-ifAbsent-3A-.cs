at: key ifAbsent: aBlock 
	"Answer the value associated with the key or, if key isn't found,
	answer the result of evaluating aBlock."

	| assoc |
	assoc := array at: (self findElementOrNil: key).
	assoc ifNil: [^ aBlock value].
	^ assoc value