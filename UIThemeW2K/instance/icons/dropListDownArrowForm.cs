dropListDownArrowForm
	"Answer the form to use for window close buttons with mouse down and over."

	^self forms at: #dropListDownArrow ifAbsent: [Form extent: 7@7 depth: Display depth]