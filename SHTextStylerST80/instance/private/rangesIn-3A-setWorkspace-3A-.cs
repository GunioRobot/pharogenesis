rangesIn: aText setWorkspace: aBoolean
	"Answer a collection of SHRanges by parsing aText.
	When formatting it is not necessary to set the workspace, and this can make the parse take less time, so aBoolean specifies whether the parser should be given the workspace"

	parser ifNil: [parser := SHParserST80 new].
	^parser 
		rangesIn: aText asString 
		classOrMetaClass: classOrMetaClass 
		workspace: (aBoolean ifTrue:[workspace])  
		environment: environment
