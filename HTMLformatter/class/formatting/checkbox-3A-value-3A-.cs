checkbox: buttonname value: b 
	^ '<INPUT TYPE="checkbox" NAME="' , buttonname , '"' , (b
			ifTrue: [' CHECKED ']
			ifFalse: ['']) , '>'