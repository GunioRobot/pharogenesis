initialize
"initialize the state of the receiver"
	super initialize.
""
	type _ #literal.
	self
		useForm: (ScriptingSystem formAtKey: #Menu)