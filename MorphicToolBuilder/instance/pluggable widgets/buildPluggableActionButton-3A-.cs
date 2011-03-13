buildPluggableActionButton: aSpec
	| button |
	button := self buildPluggableButton: aSpec.
	button beActionButton.
	^button