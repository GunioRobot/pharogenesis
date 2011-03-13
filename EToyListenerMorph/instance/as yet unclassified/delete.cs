delete

	listener ifNotNil: [listener stopListening. listener _ nil].	
					"for old instances that were locally listening"
	super delete.