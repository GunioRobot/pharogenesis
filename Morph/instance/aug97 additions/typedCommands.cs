typedCommands
	"Return a list of typed-command arrays of the form:
		<result type> <command> <argType>"

	^	#(	(command	beep:		sound)
			(command	forward: 	number)
			(command 	hide)
			(command 	show))

