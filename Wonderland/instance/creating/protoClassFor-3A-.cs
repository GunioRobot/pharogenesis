protoClassFor: aFilename
	| localName protoClass |
	localName _ FileDirectory localNameFor: aFilename.
	(ActorPrototypeClasses includesKey: localName)
			ifTrue: [ protoClass _ ActorPrototypeClasses at: localName ]
			ifFalse: ["Make a new prototype class for this model"
					protoClass _ (WonderlandActor newUniqueClassInstVars: '' classInstVars: '').
					ActorPrototypeClasses at: localName put: protoClass].
	^protoClass