plotPitchFromStream: aStream
	^ self new stream: aStream; read; plotPitch