handleKeystroke: event 
	[event isKeystroke
		ifTrue: [self process: event]]
		on: Error
		do: [:e | (self confirm: 'shortcut error. debug?') ifTrue: [e signal]]