db
	(connection isNil or: [connection isConnected not]) ifTrue: [connection _ KKDatabase onHost:hostname port: port].
	
	^ connection