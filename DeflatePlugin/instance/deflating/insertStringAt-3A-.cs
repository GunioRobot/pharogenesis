insertStringAt: here
	"Insert the string at the given start position into the hash table.
	Note: The hash value is updated starting at MinMatch-1 since
	all strings before have already been inserted into the hash table
	(and the hash value is updated as well)."
	| prevEntry |
	self inline: true.
	zipHashValue _ self updateHashAt: (here + DeflateMinMatch - 1).
	prevEntry _ zipHashHead at: zipHashValue.
	zipHashHead at: zipHashValue put: here.
	zipHashTail at: (here bitAnd: DeflateWindowMask) put: prevEntry.