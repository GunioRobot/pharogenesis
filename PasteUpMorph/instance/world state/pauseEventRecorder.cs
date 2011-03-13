pauseEventRecorder
	"Suspend any event recorder, and return it if found"

	| er |
	worldState handsDo: [:h | (er := h pauseEventRecorderIn: self) ifNotNil: [^ er]].
	^ nil