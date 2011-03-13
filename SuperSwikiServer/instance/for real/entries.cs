entries

	| answer c first |

	answer _ self sendToSwikiProjectServer: {
		'action: listallprojects'.
	}.
	(answer beginsWith: 'OK') ifFalse: [^#()].
	c _ OrderedCollection new.
	first _ true.
	answer linesDo: [ :x |
		first ifFalse: [c add: (Compiler evaluate: x)].
		first _ false.
	].
	^c
