activateTranscript
	"There is known to be a Transcript open in the current project; activate it.  2/5/96 sw"

	| itsController |
	itsController := scheduledControllers detect:
			[:controller | controller model == Transcript]
		ifNone:
			[^ self].

	self activeController: itsController.
	(activeController view labelDisplayBox
			intersect: Display boundingBox) area < 200
				ifTrue: [activeController move].
	Processor terminateActive