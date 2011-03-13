customButtonSpecs
	"Answer an array of elements of the form wording, selector, help-message, that characterize the custom button row of a debugger."

	| list |
	list := #(('Proceed'	proceed				'close the debugger and proceed.')
		('Restart'		restart				'reset this context to its start.')
		('Into'			send				'step Into message sends')
		('Over'			doStep				'step Over message sends')
		('Through'		stepIntoBlock		'step into a block')
		('Full Stack'		fullStack			'show full stack')
		('Where'		where				'select current pc range')).
	Preferences restartAlsoProceeds ifTrue:
		[list := list collect: [:each |
			each second == #restart
				ifTrue: [each copy at: 3 put: 'proceed from the beginning of this context.'; yourself]
				ifFalse: [each]]].
	^ list