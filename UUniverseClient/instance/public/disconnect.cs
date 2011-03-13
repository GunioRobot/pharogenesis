disconnect
	"explicitly close the connection"
	socket ifNotNil: [ socket destroy.  socket _ nil ].
	stringSocket ifNotNil: [ stringSocket destroy.  stringSocket _ nil ].