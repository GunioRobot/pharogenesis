requestFullName
	| initialAnswer |
	initialAnswer := fullName isEmptyOrNil
						ifTrue: ['FirstnameLastname' translated]
						ifFalse: [fullName].
	fullName := UIManager default 
			request: self messagePrompt
			initialAnswer: initialAnswer