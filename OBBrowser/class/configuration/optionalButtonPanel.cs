optionalButtonPanel
	| labels panel |
	labels _ self optionalButtons.
	(Preferences optionalButtons and: [labels isEmpty not]) ifTrue: 
		[panel _ OBFixedButtonPanel new.
		labels do: [:ea | panel addButtonWithLabel: ea]].
	^ panel