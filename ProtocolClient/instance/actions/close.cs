close
	self stream
		ifNotNil: [
			self stream close.
			stream _ nil]