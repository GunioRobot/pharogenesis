setStream: aBinaryStream
	"Initialize myself for writing on the given stream."

	stream _ aBinaryStream.
	headerStart _ aBinaryStream position.
