getResponseUpTo: markerString
	"Keep reading until the marker is seen.  Return three parts: header, marker, beginningOfData.  Fails if no marker in first 2000 chars." 

	| buf response bytesRead tester mm |
	buf _ String new: 2000.
	response _ WriteStream on: buf.
	tester _ 1. mm _ 1.
	[tester to: response position do: [:tt |
		(buf at: tt) = (markerString at: mm) ifTrue: [mm _ mm + 1] ifFalse: [mm _ 1].
			"Not totally correct for markers like xx0xx"
		mm > markerString size ifTrue: ["got it"
			^ Array with: (buf copyFrom: 1 to: tt+1-mm)
				with: markerString
				with: (buf copyFrom: tt+1 to: response position)]].
	 tester _ 1 max: response position.	"OK if mm in the middle"
	 (response position < buf size) & (self dataAvailable | self isConnected)] whileTrue: [
		(self waitForDataUntil: (Socket deadlineSecs: 5)) ifFalse: [
			Transcript show: 'data was late'; cr].
		bytesRead _ self primSocket: socketHandle receiveDataInto: buf 
			startingAt: response position + 1 count: buf size - response position.
		"response position+1 to: response position+bytesRead do: [:ii | 
			response nextPut: (buf at: ii)].	totally redundant, but needed to advance position!"
		response instVarAt: 2 "position" put: 
			(response position + bytesRead)].	"horrible, but fast"

	^ Array with: response contents
		with: ''
		with: ''		"Marker not found and connection closed"
