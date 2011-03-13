put: aString 
	| f |
	(aString size >= 5 and:
		[#('File ' '16r0 ') includes: (aString copyFrom: 1 to: 5)])
		ifTrue: [(PopUpMenu confirm:
'Abbreviated and hexadecimal file views
cannot be meaningfully saved at present.
Is this REALLY what you want to do?')
				ifFalse: [^ self]].
	f _ FileStream newFileNamed: self fullName.
	Cursor write showWhile: [f nextPutAll: aString; close].