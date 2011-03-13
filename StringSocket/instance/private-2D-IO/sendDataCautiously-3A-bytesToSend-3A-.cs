sendDataCautiously: aStringOrByteArray bytesToSend: bytesToSend
	"Send all of the data in the given array, even if it requires multiple calls to send it all. Return the number of bytes sent. Try not to send too much at once since this seemed to cause problems talking to a port on the same machine"

	| bytesSent count |

	bytesSent _ 0.
	[bytesSent < bytesToSend] whileTrue: [
		extraUnsentBytes _ bytesToSend - bytesSent.
		count _ socket 
			sendSomeData: aStringOrByteArray 
			startIndex: bytesSent + 1  
			count: (bytesToSend - bytesSent min: 6000).
		bytesSent _ bytesSent + count.
		(Delay forMilliseconds: 1) wait.
	].
	extraUnsentBytes _ 0.
	^ bytesSent
