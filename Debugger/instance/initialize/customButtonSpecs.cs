customButtonSpecs
	"Answer an array of elements of the form wording, selector, help-message, that characterize the custom button row of a debugger."

	| list |
	list _ #(('Proceed'	proceed				'close the debugger and proceed.')
		('Restart'		restart				'reset this context to its start.')
		('Into'			send				'step Into message sends')
		('Over'			doStep				'step Over message sends')
		('Through'		stepIntoBlock		'step into a block')
		('Full Stack'		fullStack			'show full stack')
		('Where'		where				'select current pc range')
		('Tally'			tally				'time in milliseconds to execute')).
	Preferences restartAlsoProceeds ifTrue:
		[list _ list collect: [:each |
			each second == #restart
				ifTrue: [each copy at: 3 put: 'proceed from the beginning of this context.'; yourself]
				ifFalse: [each]]].
	^ list