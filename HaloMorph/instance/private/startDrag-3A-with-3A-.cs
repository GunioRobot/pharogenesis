startDrag: evt with: dragHandle
	"Drag my target without removing it from its owner."

	self removeAllHandlesBut: dragHandle.
	positionOffset _ dragHandle center - self position.
