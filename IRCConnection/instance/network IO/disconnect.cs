disconnect	
	"disconnect from the server"
	socket ifNotNil: [ socket isValid ifTrue: [ 
		Transcript show: 'disconnecting from IRC', String cr.
		socket close ] ].	
	socket _ nil.