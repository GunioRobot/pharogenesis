processShutDownList
	"Call the shutDown method on each object that needs to gracefully shut itself down before a snapshot."

	(self includesKey: #Password) ifTrue: [Password shutDown].
	self shutDownSound.
	Delay shutDown.
	Smalltalk shutDown.
	Color shutDown.
	StrikeFont shutDown.
	ControlManager shutDown.
	DisplayScreen shutDown.
