getOnlyBuffer: ubuffer whileWatching: otherSocket
	"Reel in all data until the buffer is full.  At the same time, watch for errors on otherSocket.  Caller will break the connection after we have the data."

	| bytesRead ind |
	ind _ 1.
	[self isConnected | self dataAvailable] whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
			otherSocket responseError ifTrue: [self destroy. ^ #error:].
			Transcript show: 'data was late'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: ubuffer 
			startingAt: ind count: ubuffer size - ind + 1.
		(ind _ ind + bytesRead) > ubuffer size ifTrue: [^ ubuffer].
		].
	^ ubuffer	"file was shorter"