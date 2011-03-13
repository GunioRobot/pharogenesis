labelPrefix
	^ labelPrefix ifNil: [labelPrefix _ self root metaNode edges first label capitalized, ' of']