gotoLabel: labelString
	"Go to the frame with the associated label string."
	labels ifNil:[^nil].
	self frameNumber: (labels at: labelString ifAbsent:[^nil]).
	^nil