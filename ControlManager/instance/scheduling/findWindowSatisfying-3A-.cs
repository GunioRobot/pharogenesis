findWindowSatisfying: aBlock
	"Present a menu of window titles, and activate the one that gets chosen"

	| controllers labels index listToUse sortAlphabetically |
	sortAlphabetically _ Sensor optionKeyPressed.
	controllers _ OrderedCollection new.
	scheduledControllers do:
		[:controller | controller == screenController ifFalse:
			[(aBlock value: controller) ifTrue: [controllers addLast: controller]]].
	controllers size == 0 ifTrue: [^ self].
	listToUse _ sortAlphabetically
		ifTrue:
			[controllers asSortedCollection: [:a :b | a view label < b view label]]
		ifFalse:
			[controllers].
	labels _ String streamContents:
		[:strm | 
			listToUse do: [:controller | strm nextPutAll: (controller view label contractTo: 40); cr].
		strm skip: -1  "drop last cr"].
	index _ (PopUpMenu labels: labels) startUp.
	index > 0 ifTrue:
		[self activateController: (controllers at: index)]