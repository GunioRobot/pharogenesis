taskbarLabel
	"Answer the label to use for a taskbar button for the receiver."

	self model ifNotNil: [self model taskbarLabel ifNotNilDo: [:str | ^str]].
	^self labelString