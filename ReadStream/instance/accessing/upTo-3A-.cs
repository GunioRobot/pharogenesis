upTo: anObject
	"fast version using indexOf:"
	| start end |

	start _ position+1.
	end _ collection indexOf: anObject startingAt: start ifAbsent: [ 0 ].

	"not present--return rest of the collection"	
	end = 0 ifTrue: [ ^self upToEnd ].

	"skip to the end and return the data passed over"
	position _ end.
	^collection copyFrom: start to: (end-1)