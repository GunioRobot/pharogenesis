newFromUserInput
	"Can return nil if user cancel!"
	| r cabc |
	cabc _ self new.

	r _ FillInTheBlank request: 'CelesteAddressBookContact: Name of the Contact (ex IBM, George )?'.
	r = ''
		ifTrue: [^ nil].
	cabc firstName: r.

	"Ugly: because '' is valid, you cannot cancel in this point"
	r _ FillInTheBlank request: 'CelesteAddressBookContact: Surname of the Contact (ex Clooney ) [blank is accepted] ?'.
	cabc lastName: r.

	r _ FillInTheBlank request: 'CelesteAddressBookContact: Email?'.
	r = ''
		ifTrue: [^ nil].
	
	"Build a valid email suitable for a confortable reading..."
	cabc email: '"' , cabc firstName , ' ' , cabc lastName , '" ' , r.
	(self confirm: ('Please Confirm the data:\Contact to be created:\' , cabc asString) withCRs)
		ifTrue: [^ cabc]
		ifFalse: [^ nil]