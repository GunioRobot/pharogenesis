skipParens: endChar from: aVRMLStream
	| char |
	[true] whileTrue:[
		aVRMLStream skipSeparators.
		char := aVRMLStream nextChar.
		char = endChar ifTrue:[^self].
		char = $[ ifTrue:[self skipParens:$] from: aVRMLStream].
		char = ${ ifTrue:[self skipParens:$] from: aVRMLStream].
		char = $" ifTrue:[
			aVRMLStream skip: -1.
			aVRMLStream readString].
	].