okayToAccept
	self showDiffs ifFalse:
		[^ true]. 
	^ (SelectionMenu confirm: 
'Caution!  You are "showing diffs" here, so 
there is a danger that some of the text in the
code pane is contaminated by the "diff" display'
	trueChoice: 'accept anyway -- I''ll take my chances' falseChoice: 'um, let me reconsider')
