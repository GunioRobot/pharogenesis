printChunkInfo

	log == nil ifFalse: [
		log	crtab: indent; 
			print: (self chunkDescriptionFor: chunkID);
			space;
			print: (chunkLen - 6);
			nextPutAll: ' Byte'.
		log == Transcript ifTrue: [log flush].
	].