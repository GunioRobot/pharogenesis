layoutChanged
	| layout |
	fullBounds ifNil:[^self]. "layout will be recomputed so don't bother"
	fullBounds _ nil.
	layout _ self layoutPolicy.
	layout ifNotNil:[layout flushLayoutCache].
	owner ifNotNil: [owner layoutChanged].
	"note: does not send #ownerChanged here - we'll do this when computing the new layout"