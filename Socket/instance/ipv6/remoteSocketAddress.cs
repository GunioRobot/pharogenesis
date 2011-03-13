remoteSocketAddress

	| size addr |
	size := self primSocketRemoteAddressSize: socketHandle.
	addr := SocketAddress new: size.
	self primSocket: socketHandle remoteAddressResult: addr.
	^addr