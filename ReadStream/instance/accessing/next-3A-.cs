next: anInteger 
	"Answer the next anInteger elements of my collection.  overriden for efficiency"

	| ans endPosition |

	endPosition _ position + anInteger  min:  readLimit.
	ans _ collection copyFrom: position+1 to: endPosition.
	position _ endPosition.
	^ans
