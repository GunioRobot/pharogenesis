graphic
	| ff |
	ff _ self getTexturePointer.
	ff isForm ifTrue:[^ff].
	ff isMorph ifTrue:[^ff imageForm].
	^ScriptingSystem formAtKey: #Paint
