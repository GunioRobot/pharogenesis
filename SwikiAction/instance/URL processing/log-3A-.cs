log: request
	| logfile |
	logfile _ FileStream fileNamed: name , '-log.txt'.
	logfile isNil
		ifTrue: [request log: 'Failed logging on ' , name]
		ifFalse:
			[logfile setToEnd.
			request peerName isNil
			ifTrue: [logfile nextPutAll: 'UnknownPeer' , '-' ,
				request url , '-' , Time now printString , '-' ,
				Date today printString.]
			ifFalse: [logfile nextPutAll: request peerName , '-' ,
				request url , '-' , Time now printString , '-' ,
				Date today printString.].
			logfile nextPut: Character cr.
			logfile close]