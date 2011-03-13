updateCurrentStatusString

	self server ifNil:[
		currentStatusString _ '<server not active>'
	] ifNotNil:[
		currentStatusString _ 
			'server with ', 
			self server numClients printString, 
			' clients  ',
			((previousBacklog _ self server backlog) // 1024) printString,'k'
	].
