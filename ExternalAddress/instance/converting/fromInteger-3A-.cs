fromInteger: address
	"set my handle to point at address"

	(4 to: 1 by: -1) inject: address into: [:remainder :index | 
		self at: index put: (remainder bitAnd: 255).
		remainder // 256]