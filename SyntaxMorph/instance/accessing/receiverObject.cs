receiverObject
	"Return some object that could be the receiver to me (a selector).  Either the actual object who is the receiver in this message, or a guy of the right class."

	| rec value mm |
	(rec _ owner) isSyntaxMorph ifFalse: [^ nil].
	rec _ rec receiverNode.
	rec ifNil: [(rec _ owner owner) isSyntaxMorph ifFalse: [^ nil].
				rec _ rec receiverNode].	
	rec ifNil: [(rec _ owner owner owner) isSyntaxMorph ifFalse: [^ nil].
				rec _ rec receiverNode].
	rec isSelfTile ifTrue: [
		^ ((mm _ self containingWindow model) respondsTo: #targetObject) 
			ifTrue: [mm targetObject]
			ifFalse: [mm selectedClassOrMetaClass new]].
	value _ rec ifNotNil: [rec try].
	value class == Error ifTrue: [
		value _ Vocabulary instanceWhoRespondsTo: self selector].
	^ value