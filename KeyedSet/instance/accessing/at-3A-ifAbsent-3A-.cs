at: key ifAbsent: aBlock 
	"Answer the value associated with the key or, if key isn't found,
	answer the result of evaluating aBlock."

	| obj |
	obj _ array at: (self findElementOrNil: key).
	obj ifNil: [^ aBlock value].
	^ obj