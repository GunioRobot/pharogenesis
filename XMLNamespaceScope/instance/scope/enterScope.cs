enterScope
	self scope addLast: { self defaultNamespace. nil. currentBindings. }