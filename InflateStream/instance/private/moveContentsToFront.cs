moveContentsToFront
	"Move the decoded contents of the receiver to the front so that we have enough space for decoding more data."
	| delta |
	readLimit > 32768 ifTrue:[
		delta _ readLimit - 32767.
		collection 
			replaceFrom: 1 
			to: collection size - delta + 1 
			with: collection 
			startingAt: delta.
		position _ position - delta + 1.
		readLimit _ readLimit - delta + 1].