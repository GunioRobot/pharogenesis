primitiveSocket: socket listenOnPort: port backlogSize: backlog
"second part of the wierdass dual prim primitiveSocketListenOnPort which was warped by some demented evil person determined to twist the very nature of reality"
	| s |
	self var: #s declareC: 'SocketPtr s'.
	self primitive: 'primitiveSocketListenOnPortBacklog'
		parameters: #(Oop SmallInteger SmallInteger).
	s _ self socketValueOf: socket.
	self sqSocket: s ListenOnPort: port BacklogSize: backlog.