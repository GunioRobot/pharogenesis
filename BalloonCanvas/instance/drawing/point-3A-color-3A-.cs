point: pt color: c
	"Is there any use for this?"
	| myPt |
	transform 
		ifNil:[myPt _ pt]
		ifNotNil:[myPt _ transform localPointToGlobal: pt].
	^super point: myPt color: c