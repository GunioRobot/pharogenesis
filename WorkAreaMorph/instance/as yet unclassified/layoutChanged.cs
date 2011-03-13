layoutChanged
	"Don't pass to owner, since the receiver doesn't care! Improves frame rate."
	
	fullBounds := nil.
	self layoutPolicy ifNotNilDo:[:l | l flushLayoutCache].