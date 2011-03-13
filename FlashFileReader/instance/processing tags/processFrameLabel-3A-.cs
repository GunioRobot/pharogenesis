processFrameLabel: data
	| label |
	label := data nextString.
	self recordFrameLabel: label.
	^true