selector: selOrFalse arguments: args precedence: p temporaries: temps block: blk encoder: anEncoder primitive: prim 
	"Initialize the receiver with respect to the arguments given."

	encoder _ anEncoder.
	selectorOrFalse _ selOrFalse.
	precedence _ p.
	arguments _ args.
	temporaries _ temps.
	block _ blk.
	primitive _ prim