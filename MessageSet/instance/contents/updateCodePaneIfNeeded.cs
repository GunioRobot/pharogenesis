updateCodePaneIfNeeded
	"If the code for the currently selected method has changed underneath me, then update the contents of my code pane unless it holds unaccepted edits.
	Overridden here in order not to set contents to nil"

	self didCodeChangeElsewhere
		ifTrue:
			[self hasUnacceptedEdits
				ifFalse:
					[self contentsChanged]
				ifTrue:
					[self changed: #codeChangedElsewhere]]