undeclared: name

	| sym |
	requestor interactive ifTrue: [
		requestor requestor == #error: ifTrue: [requestor error: 'Undeclared'].
		^ self notify: 'Undeclared'].
	Transcript show: ' (' , name , ' is Undeclared) '.
	sym _ name asSymbol.
	Undeclared at: sym put: nil.
	^self global: (Undeclared associationAt: sym) name: sym