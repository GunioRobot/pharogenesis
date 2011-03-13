localNameFor: fileName
	pathName isEmpty ifTrue: [^ fileName].
	pathName size >= fileName size ifTrue: [String new].
	(pathName, '*' match: fileName)
		ifTrue: [^ fileName copyFrom: pathName size+2
							to: fileName size].
	^ String new