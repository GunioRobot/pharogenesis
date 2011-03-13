windowFromUser
	"Present a menu of window titles, and returns the StandardSystemController belonging to the one that gets chosen, or nil if none"
	| controllers labels index |
	controllers _ OrderedCollection new.
	labels _ String streamContents:
		[:strm |
		scheduledControllers do:
			[:controller | controller == screenController ifFalse:
				[controllers addLast: controller.
				strm nextPutAll: (controller view label contractTo: 40); cr]].
		strm skip: -1  "drop last cr"].
	index _ (PopUpMenu labels: labels) startUp.
	^ index > 0
		ifTrue:
			[controllers at: index]
		ifFalse:
			[nil]