processFrameLabel: data
	| label |
	label _ data nextString.
	self recordFrameLabel: label.
	^true