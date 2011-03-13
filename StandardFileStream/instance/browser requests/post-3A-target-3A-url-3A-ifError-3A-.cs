post: data target: target url: url ifError: errorBlock
	"Post data to the given URL. The returned file stream contains the reply of the server.
	If Squeak is not running in a browser evaluate errorBlock"
	| sema index request result |
	self waitBrowserReadyFor: self defaultBrowserReadyWait ifFail: [^errorBlock value].
	sema := Semaphore new.
	index := Smalltalk registerExternalObject: sema.
	request := self primURLPost: url target: target data: data semaIndex: index.
	request == nil ifTrue:[
	
	Smalltalk unregisterExternalObject: sema.
		^errorBlock value.
	] ifFalse:[
		[sema wait. "until something happens"
		result := self primURLRequestState: request.
		result == nil] whileTrue.
		result ifTrue:[fileID := self primURLRequestFileHandle: request].
		self primURLRequestDestroy: request.
	].
	Smalltalk unregisterExternalObject: sema.
	fileID == nil ifTrue:[^nil].
	self register.
	name := url.
	rwmode := false.
	buffer1 := String new: 1.