dispatchOnEnterWith: typeAheadStream
	"Enter key hit.  Treat is as an 'accept', viz a synonym for cmd-s.  If cmd key is down, treat is as a synonym for print-it. "

	self terminateAndInitializeAround: [
	Sensor commandKeyPressed
		ifTrue:
			[self printIt.]
		ifFalse: 
			[self closeTypeIn: typeAheadStream.
			self accept].
	].
	^ true