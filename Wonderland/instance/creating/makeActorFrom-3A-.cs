makeActorFrom: filename
	"Creates a new actor using the specification from the given file"

	| aFile words line startSubstr index parent name texture meshFile matrix baseActor newActor protoClass actorClass fileVersion |

	myUndoStack closeStack.
	words _ (filename findTokens: #.).

	((words last) = 'mdl') ifTrue: [
			aFile _ (CrLfFileStream readOnlyFileNamed: filename) ascii.

			"First see if we need to create a prototype class for this model"
			(ActorPrototypeClasses includesKey: (aFile localName))
					ifTrue: [ protoClass _ ActorPrototypeClasses at: (aFile localName) ]
					ifFalse: [
							"Make a new prototype class for this model"
							protoClass _ (WonderlandActor newUniqueClassInstVars: ''
															classInstVars: '').
							ActorPrototypeClasses at: (aFile localName) put: protoClass.
							].

			"Check what version this mdl file is"
			line _ aFile upTo: (Character cr).
			line _ aFile upTo: (Character cr).
			line _ aFile upTo: (Character cr).

			((line truncateTo: 7) = 'version')
					ifTrue: [ fileVersion _ 1 ]
					ifFalse: [ fileVersion _ 0 ].

			[ line _ aFile upTo: (Character cr).
			  (aFile atEnd) ifTrue: [ true ]
			  			ifFalse: [ words _ line findTokens: '='.
								  false ]
			] whileFalse: [

					"See if we're creating a new object"
					(((words size) > 1) and: [ ((words at: 2) beginsWith: ' _MakeObject')
											or: [ (words at: 2) beginsWith: ' Alice.MakeObject' ] ])

						ifTrue: [
						(fileVersion = 0)
							ifTrue: [
								words _ line findTokens: #,.
								parent _ (words at: 2) withBlanksTrimmed.
								name _ (((words at: 3) withBlanksTrimmed)
													findBetweenSubStrs: '"') at: 1.
									]
							ifFalse: [
								name _ (words at: 1) truncateTo: (((words at: 1) size) - 1).
								parent _ ((words at: 3) findTokens: #,) at: 1.
									].

						"Now pull in the texture to use"
						startSubstr _ name , '.SetTexture'.
						[(line _ aFile upTo: (Character cr)) beginsWith: startSubstr] whileFalse: [].

						texture _ (line findBetweenSubStrs: '"') at: 2.
						texture _ (aFile directory pathName), FileDirectory slash, texture.

						"Read the composite matrix to use"
						startSubstr _ name , '._SetLocalTransformation'.
						[(line _ aFile upTo: (Character cr)) beginsWith: startSubstr] whileFalse: [].

						matrix _ B3DMatrix4x4 new.
						words _ line findBetweenSubStrs: ',()'.
						words removeAllSuchThat: [:str | str = ' '].

						index _ words size.
						4 to: 1 by: -1 do: [:i | 
							4 to: 1 by: -1 do: [:j | matrix at: i at: j put: 
										((words at: index) withBlanksTrimmed) asNumber.
										   		index _ index - 1. ]. ].

						1 to: 4 do: [:i | index _ matrix at: i at: 4.
									   matrix at: i at: 4 put: (matrix at: 4 at: i).
									   matrix at: 4 at: i put: index. ].

						matrix a14: (matrix a14 negated).

						"Read the mesh file to use"
						startSubstr _ 'LoadGeometry'.
						[(line _ aFile upTo: (Character cr)) beginsWith: startSubstr] whileFalse: [].

						meshFile _ (line findBetweenSubStrs: '"') at: 2.
						meshFile _ (aFile directory pathName), FileDirectory slash, meshFile.

						"Now build the actor name"
						words _ name findTokens: '.'.
						name _ words last.
						name at: 1 put: ((name at: 1) asLowercase).

						"Now build the parent name"
						parent _ parent copyReplaceAll: '.' with: ' '.

						"Now create the object"
						(parent = 'None') ifTrue: [
								actorClass _ protoClass newUniqueClassInstVars: '' classInstVars: ''.
								baseActor _ actorClass createFor: self.
								actorClassList addLast: actorClass.
								baseActor setName: name.
								baseActor setTexture: texture.
								baseActor loadMeshFromFile: meshFile.
								baseActor setComposite: matrix.
												]  "end base actor creation"

										ifFalse: [
								actorClass _ WonderlandActor newUniqueClassInstVars: ''
																classInstVars: ''.
								newActor _ actorClass createFor: self.
								actorClassList addLast: actorClass.
								newActor setName: name.
								parent _ (baseActor getChildNamed: parent).
								newActor reparentTo: parent.
								newActor becomePart.
								newActor setTexture: texture.
								newActor loadMeshFromFile: meshFile.
								newActor setComposite: matrix.
												]. "end new actor with parent"

															]. "end MakeObject parsing"

											]. "end file parsing"

			aFile close.
			myUndoStack openStack.

			"Ensure that the new actor's name is unique"
			name _ self uniqueNameFrom: (baseActor getName).
			baseActor setName: name.
			myNamespace at: name put: baseActor.
			scriptEditor updateActorBrowser.

			"Add an undo item to undo the creation of this object"
			myUndoStack push: (UndoAction new: [ baseActor removeFromScene.
													myNamespace removeKey: name ifAbsent: [].
													scriptEditor updateActorBrowser.  ] ).

			^ baseActor.
								]. " end mdl file parsing"