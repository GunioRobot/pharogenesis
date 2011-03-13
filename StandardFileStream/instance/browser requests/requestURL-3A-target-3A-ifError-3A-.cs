requestURL: url target: target ifError: errorBlock
	"Request to go to the target for the given URL.
	If Squeak is not running in a browser evaluate errorBlock"

	| sema index request result |
	self waitBrowserReadyFor: self defaultBrowserReadyWait ifFail: [^errorBlock value].
	sema := Semaphore new.
	index := Smalltalk registerExternalObject: sema.
	request := self primURLRequest: url target: target semaIndex: index.
	request == nil ifTrue:[
	
	Smalltalk unregisterExternalObject: sema.
		^errorBlock value.
	] ifFalse:[
		[sema wait. "until something happens"
		result := self primURLRequestState: request.
		result == nil] whileTrue.
		self primURLRequestDestroy: request.
	].
	Smalltalk unregisterExternalObject: sema.
	fileID == nil ifTrue:[^nil].
	self register.
	name := url.
	rwmode := false.
	buffer1 := String new: 1.