removeFileEntry: aMpegFile
	self var: #aMpegFile declareC: 'mpeg3_t * aMpegFile'.
	1 to: maximumNumberOfFilesToWatch do: 
		[:i | ((mpegFiles at: i) = aMpegFile) ifTrue: 
				[mpegFiles at: i put: 0.
				^true]].
	"Just ignore"
	^false
		
	