readFrom: aVRMLStream in: aParser
	"Read a node"
	| assoc vrmlInstance |
	vrmlInstance := self newInstance.
	aParser defineNode: vrmlInstance.
	aVRMLStream skipSeparators.
	aVRMLStream nextChar = ${ ifFalse:[^self error:'Node definition expected'].
	[aVRMLStream skipSeparators.
	aVRMLStream peekChar = $}] whileFalse:[
		assoc := self readAttributeFrom: aVRMLStream in: aParser.
		assoc ifNotNil:[assoc key setValue: assoc value in: vrmlInstance].
	].
	aVRMLStream nextChar.
	^vrmlInstance