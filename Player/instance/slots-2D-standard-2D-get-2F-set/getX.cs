getX
		"emergency patch; unclear why not needed in getY; in any case, have
		 removed the getX/getY retrievals from the viewer in 2.0-final anyway"
	costume isInWorld ifFalse: [^ 100].
	^ costume x