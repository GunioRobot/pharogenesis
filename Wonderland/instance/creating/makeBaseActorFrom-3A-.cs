makeBaseActorFrom: filename
	| protoClass actorClass baseActor name |
	"First see if we need to create a prototype class for this model"
	protoClass _ self protoClassFor: filename.
	"Base actor creation"
	actorClass _ protoClass newUniqueClassInstVars: '' classInstVars: ''.
	baseActor _ actorClass createFor: self.
	actorClassList addLast: actorClass.
	name _ FileDirectory localNameFor: filename.
	(name findString: FileDirectory dot) = 0 ifFalse:[
		name _ name copyFrom: 1 to: (name findString: FileDirectory dot)-1].
	baseActor setName: (self uniqueNameFrom: name).
	^baseActor