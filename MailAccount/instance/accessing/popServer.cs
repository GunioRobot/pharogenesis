popServer
	"Answer the server for downloading email via POP"
	popServer isEmptyOrNil ifTrue:[
		self error: 'POP server not specified'.
	].
	^popServer.