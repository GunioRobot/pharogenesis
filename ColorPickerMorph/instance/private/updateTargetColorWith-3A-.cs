updateTargetColorWith: aColor
	"Update the target so that it reflects aColor as the color choice"

	(target ~~ nil and: [selector ~~ nil]) ifTrue:
		[self updateSelectorDisplay.
		^ target perform: selector withArguments: (self argumentsWith: aColor)]
