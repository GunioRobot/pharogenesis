chooseActorName
	| newName |

	newName _ FillInTheBlank request: 'New Name?' initialAnswer: argument externalName asString.
 	newName size == 0 ifTrue: [^ self].
	argument setNameTo: newName