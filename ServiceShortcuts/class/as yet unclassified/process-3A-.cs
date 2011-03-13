process: event 
	event keyCharacter isDigit
		ifTrue: [event commandKeyPressed & event controlKeyPressed
				ifTrue: [^ self shortcut: 'ctrl-cmd-' event: event].
			event commandKeyPressed
				ifTrue: [^ self shortcut: 'cmd-' event: event].
			event controlKeyPressed
				ifTrue: [^ self shortcut: 'ctrl-' event: event]].
	({Character arrowUp. Character arrowDown. Character arrowLeft. Character arrowRight} includes: event keyCharacter)
		ifTrue: [event commandKeyPressed & event controlKeyPressed
				ifTrue: [^ self arrowShortcut: 'ctrl-cmd-' event: event].
			]