getResponseUpTo: markerString ignoring: ignoreString
	"Keep reading, until the marker is seen, skipping characters in ignoreString when
      comparing to the marker.  Return three parts: header, marker, beginningOfData.
     Fails if no marker in first 2000 chars." 

	| buf response bytesRead tester mm skipped |
	buf := String new: 2000.
	response := WriteStream on: buf.
	tester := 1. mm := 1.
	skipped := 0.
	[tester := tester - markerString size + 1 max: 1.  "rewind a little, in case the marker crosses a read boundary"
	tester to: response position do: [:tt |
		(buf at: tt) = (markerString at: mm) ifFalse:
			[[ignoreString includes: (markerString at: mm)] whileTrue:
				[mm := mm + 1. skipped := skipped + 1]].
		(buf at: tt) = (markerString at: mm)
			ifTrue: [mm := mm + 1]
			ifFalse: [mm := 1. skipped := 0].
			"Not totally correct for markers like xx0xx"
		mm > markerString size ifTrue: ["got it"
			^ Array with: (buf copyFrom: 1 to: tt+1-mm+skipped)
				with: markerString
				with: (buf copyFrom: tt+1 to: response position)]].
	 tester := 1 max: response position.	"OK if mm in the middle"
	 (response position < buf size) & (self isConnected | self dataAvailable)] whileTrue: [
		self waitForDataFor: 5 ifClosed: [
				Transcript show: ' <connection closed> ']
			ifTimedOut: [
				Transcript show: 'data was late'].
		bytesRead := self primSocket: socketHandle receiveDataInto: buf 
			startingAt: response position + 1 count: buf size - response position.
		"response position+1 to: response position+bytesRead do: [:ii | 
			response nextPut: (buf at: ii)].	totally redundant, but needed to advance position!"
		response instVarAt: 2 "position" put: 
			(response position + bytesRead)].	"horrible, but fast"

	^ Array with: response contents
		with: ''
		with: ''		"Marker not found and connection closed"
