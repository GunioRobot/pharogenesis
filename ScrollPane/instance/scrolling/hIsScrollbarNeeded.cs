hIsScrollbarNeeded
"Return whether the horz scrollbar is needed"

	"Don't do anything with the retractable scrollbar unless we have focus"
	retractableScrollBar & self hasFocus not ifTrue: [^false].
	
	"Don't show it if we were told not to."
	(self valueOfProperty: #noHScrollBarPlease ifAbsent: [false]) ifTrue: [^false].

	"Always show it if we were told to"
	(self valueOfProperty: #hScrollBarAlways ifAbsent: [false]) ifTrue: [^true].

	^self hIsScrollable
