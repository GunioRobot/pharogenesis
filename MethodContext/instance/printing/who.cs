who
	| sel mcls |
	self method ifNil: [^ Array with: #unknown with: #unknown].
	sel _ self receiver class
			selectorAtMethod: self method 
			setClass: [:c | mcls _ c].
	sel == #? ifTrue: [^ self method who].
	^ Array with: mcls with: sel
