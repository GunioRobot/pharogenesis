writeClone  "SystemTracer writeClone"
	| tracer |
	tracer _ self new.
	"Delay shutDown."  "part of Smalltalk processShutDownList."
	tracer doit.   " <-- execution in clone resumes after this send"
	tracer == nil "will be nil in clone, since it is clamped"
		ifTrue: [Smalltalk processStartUpList: true].
	^ tracer