primitiveSocket: socket listenOnPort: port backlogSize: backlog 
	"second part of the wierdass dual prim primitiveSocketListenOnPort 
	which was warped by some demented evil person determined to twist the 
	very nature of reality"
	| s okToListen |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketListenOnPortBacklog' parameters: #(#Oop #SmallInteger #SmallInteger ).
	s _ self socketValueOf: socket.
	"If the security plugin can be loaded, use it to check for permission.
	If 
	not, assume it's ok"
	sCCLOPfn ~= 0
		ifTrue: [okToListen _ self cCode: ' ((int (*) (SocketPtr, int)) sCCLOPfn)(s, port)'.
			okToListen
				ifFalse: [^ interpreterProxy primitiveFail]].
	self
		sqSocket: s
		ListenOnPort: port
		BacklogSize: backlog