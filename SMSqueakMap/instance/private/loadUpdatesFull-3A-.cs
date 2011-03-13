loadUpdatesFull: full
	"Find a server and load updates from it."
 
	| server |
	server := self class findServer.
	server ifNotNil: [
		self synchWithDisk.
		full ifTrue: [self loadFullFrom: server]
			ifFalse:[self error: 'Not supported yet!'."self loadUpdatesFrom: server"]]