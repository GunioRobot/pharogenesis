mouseEnter: evt
	owner stayUp ifFalse:[self mouseEnterDragging: evt].