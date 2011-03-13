okayToAccept
	"Answer whether it is okay to accept the receiver's input"

	self showingDocumentation ifTrue:
		[self inform: 
'Sorry, for the moment you can
only submit changes here when
you are showing source.  Later, you
will be able to edit the isolated comment
here and save it back, but only if you
implement it!.' translated.
		^ false].

	self showingAnyKindOfDiffs ifFalse:
		[^ true]. 
	^ self confirm: 
'Caution!
You are "showing diffs" here, so 
there is a danger that some of the text in the
code pane is contaminated by the "diff" display' translated
