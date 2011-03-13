delete
	self server ifNotNil:[
		(self confirm:'Shutdown the server?') 
			ifTrue:[self world remoteServer: nil]].
	super delete.