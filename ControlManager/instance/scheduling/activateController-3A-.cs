activateController: aController
	"Make aController, which must already be a scheduled controller, the active window.  5/8/96 sw"

	self activeController: aController.
	(activeController view labelDisplayBox
		intersect: Display boundingBox) area < 200
			ifTrue: [activeController move].
	Processor terminateActive