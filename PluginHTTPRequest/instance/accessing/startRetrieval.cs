startRetrieval
	| attempts |
	attempts _ self maxAttempts.
	"Note: Only the first request may fail due to not running in a browser"
	url first = $/
		ifTrue: [url _ url copyFrom: 2 to: url size].
	fileStream _ FileStream requestURLStream: url ifError:[^super startRetrieval].
	[fileStream == nil] whileTrue:[
		attempts _ attempts - 1.
		attempts = 0 ifTrue:[^self content:'Error downloading file'].
		fileStream _ FileStream requestURLStream: url].
	semaphore signal.