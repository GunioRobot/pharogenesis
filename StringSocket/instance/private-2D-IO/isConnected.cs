isConnected

	^super isConnected and: [socketWriterProcess notNil]