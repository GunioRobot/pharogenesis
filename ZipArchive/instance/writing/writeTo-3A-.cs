writeTo: stream
	stream binary.
	members do: [ :member |
		member writeTo: stream.
		member endRead.
	].
	writeCentralDirectoryOffset _ stream position.
	self writeCentralDirectoryTo: stream.
	