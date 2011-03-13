processShutDownList
	"Call the shutDown method on each object that needs to gracefully shut itself down before a snapshot."

	Smalltalk at: #PWS ifPresent: [:pws | pws stopServer].
	Smalltalk at: #Password ifPresent: [:password | password shutDown].
	self shutDownSound.
	Delay shutDown.
	Smalltalk shutDown.
	Color shutDown.
	StrikeFont shutDown.
	Smalltalk isMorphic ifFalse: [ControlManager shutDown].
	Form shutDown.
	DisplayScreen shutDown.
