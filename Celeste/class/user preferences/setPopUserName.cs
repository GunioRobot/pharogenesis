setPopUserName
	"set the POP server used for downloading email"

	(PopUserName isNil) ifTrue: [PopUserName _ ''].
	PopUserName _ FillInTheBlank
		request: 'What is your username on your POP server?'
		initialAnswer: PopUserName.

	"be kind, if they include the host name here"
	(PopUserName includes: $@) ifTrue: [
		PopUserName _ PopUserName copyFrom: 1 to: (PopUserName indexOf: $@)-1 ].