requestURLStream: url ifError: errorBlock
	"Request a FileStream for the given URL.
	If Squeak is not running in a browser evaluate errorBlock"
	"FileStream requestURLStream:'http://www.squeak.org'"
	| sema index request result |
	self waitBrowserReadyFor: self defaultBrowserReadyWait ifFail: [^errorBlock value].
	sema _ Semaphore new.
	index _ Smalltalk registerExternalObject: sema.
	request _ self primURLRequest: url semaIndex: index.
	request == nil ifTrue:[
	
	Smalltalk unregisterExternalObject: sema.
		^errorBlock value.
	] ifFalse:[
		[sema wait. "until something happens"
		result _ self primURLRequestState: request.
		result == nil] whileTrue.
		result ifTrue:[fileID _ self primURLRequestFileHandle: request].
		self primURLRequestDestroy: request.
	].
	Smalltalk unregisterExternalObject: sema.
	fileID == nil ifTrue:[^nil].
	self register.
	name _ url.
	rwmode _ false.
	buffer1 _ String new: 1.