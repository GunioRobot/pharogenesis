pauseEventRecorder
	"Suspend any event recorder, and return it if found"

	| er |
	self handsDo: [:h | (er _ h pauseEventRecorderIn: self) ifNotNil: [^ er]].
	^ nil