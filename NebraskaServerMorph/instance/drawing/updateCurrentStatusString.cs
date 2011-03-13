updateCurrentStatusString

	self server ifNil:[
		currentStatusString := '<Nebraska not active>' translated.
		currentBacklogString := ''.
	] ifNotNil:[
		currentStatusString := 
			' Nebraska: ' translated, 
			self server numClients printString, 
			' clients' translated.
		currentBacklogString := 'backlog: ' translated,
				((previousBacklog := self server backlog) // 1024) printString,'k'
	].
