findWindowSatisfying: aBlock
	"Present a menu of window titles, and activate the one that gets chosen
	 1/18/96 sw: Created this version with an argument for more general use, and also, as per Dan's request, modified so that windows whose topleft corners are beyond the lower-right screen corner get picked up by the window-rescue piece.
	 5/8/96 sw: use activateController:"

	| controllers labels index |
	controllers _ OrderedCollection new.
	labels _ String streamContents:
		[:strm |
		scheduledControllers do:
			[:controller | controller == screenController ifFalse:
				[(aBlock value: controller) ifTrue:
					[controllers addLast: controller.
					strm nextPutAll: (controller view label contractTo: 40); cr]]].
		strm position == 0 ifTrue: [^ self].  "Nothing satisfies"
		strm skip: -1  "drop last cr"].

	index _ (PopUpMenu labels: labels) startUp.
	index > 0 ifTrue:
		[self activateController: (controllers at: index)]