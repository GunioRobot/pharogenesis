columns
	| a |
	a _ self getAttribute: 'cols' default: '20'.
	^(Integer readFrom: (ReadStream on: a)) max: 5.