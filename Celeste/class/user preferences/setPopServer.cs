setPopServer
	"Change the user's email name for use in composing messages."

	(PopServer isNil) ifTrue: [PopServer _ ''].
	PopServer _ FillInTheBlank
		request: 'What is your POP server''s hostname?'
		initialAnswer: PopServer.
