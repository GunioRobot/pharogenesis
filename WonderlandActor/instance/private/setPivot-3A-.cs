setPivot: aVector
	"Modify the object to use the specified point as the pivot point."

	| matrix invMatrix b3dVector |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTarget: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what pivot to use because ', msg.
			^ nil ].


	"Our parameters check out, so change the pivot"
	(aVector isKindOf: WonderlandActor)
		ifTrue: [ matrix _ aVector getMatrixFromRoot. ]
		ifFalse: [ b3dVector _ B3DVector3 x: (aVector at: 1) y: (aVector at: 2)
									z: (aVector at: 3).
				  matrix _ B3DMatrix4x4 identity translation: b3dVector ].

	"Add an undo action"
	b3dVector _ self getMatrixFromRoot translation.
	myWonderland getUndoStack push: (UndoAction new: [self setPivot: b3dVector ]).

	invMatrix _ (matrix inverseTransformation) composeWith: (self getMatrixFromRoot).

	myMesh ifNotNil: [ myMesh _ myMesh copy.
					    myMesh vertices: (myMesh vertices copy).
					    myMesh transformBy: invMatrix ].

	composite _ (myParent getMatrixToRoot) composeWith: matrix.

	(self getChildren) do: [:child | child setComposite:
										(invMatrix composeWith: (child getComposite)) ].

