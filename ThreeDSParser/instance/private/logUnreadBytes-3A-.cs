logUnreadBytes: nextChunkPos

	| pos |
	log isNil ifFalse: [
		pos := source position.
		pos = (chunkPos + 6)
			ifFalse: [log crtab: indent + 1; print: nextChunkPos - pos;
				nextPutAll: ' Byte'].
		log nextPutAll: ' unread 		***']