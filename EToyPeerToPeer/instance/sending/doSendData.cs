doSendData

	| totalLength myData allTheData |

	myData _ dataQueue next ifNil: [socket sendData: '0 '. ^false].
	totalLength _ (myData collect: [ :x | x size]) sum.
	socket sendData: totalLength printString,' '.
	allTheData _ WriteStream on: (String new: totalLength).
	myData do: [ :chunk | allTheData nextPutAll: chunk asString].
	NebraskaDebug at: #peerBytesSent add: {totalLength}.
	self sendDataCautiously: allTheData contents.
	^true

