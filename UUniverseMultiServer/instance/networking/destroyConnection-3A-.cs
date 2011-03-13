destroyConnection: aConnection
	aConnection destroy.
	connections remove: aConnection ifAbsent: [].
	