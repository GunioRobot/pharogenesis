updateCurrentStatusString

	self server ifNil:[
		currentStatusString _ '<Nebraska not active>' translated.
		currentBacklogString _ ''.
	] ifNotNil:[
		currentStatusString _ 
			' Nebraska: ' translated, 
			self server numClients printString, 
			' clients' translated.
		currentBacklogString _ 'backlog: ' translated,
				((previousBacklog _ self server backlog) // 1024) printString,'k'
	].
