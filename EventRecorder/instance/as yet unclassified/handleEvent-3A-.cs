handleEvent: anEvent
	"Start, Stop, and record events.  Playback.  5/21/97 tk"
"state = nil   stopped, not recording
 	= #record	recording
	= #play		playing back
Control 1 = start recording
Control 2 = stop recording (or playing back)
Control 3 = start playing back"

state == nil ifTrue: [^ self testControl: anEvent].
state == #record ifTrue: [tape addLast: anEvent.
	^ self testControl: anEvent].
state == #play ifTrue: [^ self testControl: anEvent].	"ignore my own events.  
	Playback happens from another method."

"AA _ EventRecorder new.
hands first startReportingEventsTo: AA. "