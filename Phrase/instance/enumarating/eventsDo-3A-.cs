eventsDo: aBlock
	self words do: [ :word | word eventsDo: aBlock]