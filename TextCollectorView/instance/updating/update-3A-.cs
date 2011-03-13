update: aParameter
	"Transcript cr; show: 'qwre'.    Transcript clear."
	aParameter == #appendEntry ifTrue:
		[(self controller isKindOf: TextCollectorController) ifTrue: 
			[^ ScheduledControllers bring: self topView controller
				nextToTopFor: [controller appendEntry]]].
	aParameter == #update ifTrue:
		[(self controller isKindOf: TextCollectorController) ifTrue: 
			[^ ScheduledControllers bring: self topView controller
				nextToTopFor: [controller changeText: model contents asText]]].
	^ super update: aParameter