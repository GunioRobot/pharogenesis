testStreamUseGivenCollection
	"self debug: #testStreamUseGivenCollection"
	
	"When a stream is created on a collection, it tries to keep using that collection instead of copying. See thread with title 'Very strange bug on Streams and probably compiler' (Feb 14 2007) on the squeak-dev mailing list."
	
	|string stream|
	
	string := String withAll: 'erased'.
	stream := WriteStream on: string.
	self assert: string = 'erased'.
	
	stream nextPutAll: 'test'.
	self assert: string = 'tested'. "Begining of 'erased' has been replaced by 'test'".