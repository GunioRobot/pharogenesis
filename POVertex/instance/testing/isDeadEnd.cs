isDeadEnd
	^ self isConnected and: [self halfedge opposite next = self halfedge]