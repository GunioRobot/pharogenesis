parseScript: aVRMLStream

	aVRMLStream skipSeparators.
	aVRMLStream next = ${ ifFalse:[^self error: 'Script definition expected'].
	self skipParens: $} from: aVRMLStream.
	^VRMLUndefinedNode new.