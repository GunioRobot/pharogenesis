loadUpdatesFrom: aStream log: doLogging
	"Load updates from the stream.
	This updates the model in memory and if <doLogging>
	is true we also log the updates in the local log file."

	| chunk file |
	[ doLogging ifTrue:[ file _ self openLogFile setToEnd ].
	[aStream atEnd]
		whileFalse: [
			chunk _ aStream nextChunk.
			Compiler evaluate: chunk for: self logged: false.
			doLogging ifTrue: [file cr; nextChunkPut: chunk].
		]] ensure: [
			aStream close.
			doLogging ifTrue:[file close]]