initDict
	writeDict _ Dictionary new: 256.
	Smalltalk allClassesDo: 
		[:class | 
		class isBits 
			ifTrue: 
			[writeDict at: class put: (class isBytes ifTrue: [#writeBytes:]
												ifFalse: [#writeWords:])]
			ifFalse:
			[writeDict at: class put: #writePointers:.
			(class inheritsFrom: Set) | (class == Set) ifTrue:
				[writeDict at: class put: #writeSet:].
			(class inheritsFrom: IdentitySet) | (class == IdentitySet) ifTrue:
				[writeDict at: class put: #writeIdentitySet:].
			(class inheritsFrom: IdentityDictionary) | (class == IdentityDictionary) ifTrue:
				[writeDict at: class put: #writeIdentitySet:].
			(class inheritsFrom: MethodDictionary) | (class == MethodDictionary) ifTrue:
				[writeDict at: class put: #writeMethodDictionary:]].
				].
	Smalltalk allBehaviorsDo: 
		[:class | writeDict at: class class put: #writeBehavior:].
	(ObjectTracer withAllSubclasses) do: 
		[:class | writeDict at: class class put: #writeBehavior:].
	writeDict at: PseudoContext class put: #writeBehavior:.
	writeDict at: SmallInteger put: #writeClamped:.
	writeDict at: CompiledMethod put: #writeMethod:.
	writeDict at: Process put: #writeProcess:.
	writeDict at: MethodContext put: #writeContext:.
	writeDict at: BlockContext put: #writeContext:.