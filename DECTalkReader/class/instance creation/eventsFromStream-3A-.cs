eventsFromStream: aStream
	^ self new stream: aStream; read; events