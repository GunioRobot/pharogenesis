getTOC: timecode doStreams: streams
	| buffer |
	
	buffer _ String new: 64*1024+1.
	self primGenerateToc: self fileHandle useSearch: timecode doStreams: streams buffer: buffer.
	^buffer