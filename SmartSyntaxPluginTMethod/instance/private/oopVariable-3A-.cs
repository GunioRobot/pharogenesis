oopVariable: aString

	(locals includes: aString) ifFalse:
		[locals add: aString.
		 declarations
			at: aString 
			put: 'int ', aString].
	^TVariableNode new setName: aString