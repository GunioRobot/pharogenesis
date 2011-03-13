buttonLabelFor: aButton
	"Answer the label to use for the given button."

	|label|
	label := self buttonLabelForText: aButton label.
	(label respondsTo: #enabled:) ifTrue: [
		label enabled: aButton enabled].
	label font: Preferences standardButtonFont.
	^label