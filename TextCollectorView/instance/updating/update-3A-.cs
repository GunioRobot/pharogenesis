update: aParameter
	"Transcript cr; show: 'qwre'.    Transcript clear."
	aParameter == #appendEntry ifTrue:
		[^ controller doOccluded: [controller appendEntry]].
	aParameter == #update ifTrue:
		[^ controller doOccluded:
				[controller changeText: model contents asText]].
	^ super update: aParameter