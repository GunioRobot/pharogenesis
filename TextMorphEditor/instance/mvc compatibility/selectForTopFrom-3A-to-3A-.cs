selectForTopFrom: start to: stop

	self selectFrom: start to: stop.
	morph editView ifNotNil: [self selectAndScrollToTop]