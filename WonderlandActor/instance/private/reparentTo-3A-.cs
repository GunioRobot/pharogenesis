reparentTo: anObject
	"Make this actor a child of the specified object."

	| newComposite classList parentClass |

	classList _ myWonderland getActorClassList.

	"First break ties with the current parent"
	myParent removeChild: self.
	parentClass _ myParent class.

	(parentClass == WonderlandScene)
		ifTrue: [
				myWonderland getNamespace removeKey: myName ifAbsent: [].
				]
		ifFalse: [
				classList remove: parentClass.
				parentClass removeSelector: (myName asSymbol).
				parentClass removeInstVarName: myName.
				classList addLast: (myParent class).
				].

	"Figure out the new composite transformation matrix"
	newComposite _ anObject getMatrixToRoot.
	newComposite _ newComposite composeWith: (self getMatrixFromRoot).
	
	"Now build ties with the new parent"
	anObject addChild: self.
	myParent _ anObject.
	parentClass _ myParent class.

	(parentClass == WonderlandScene)
		ifTrue: [
				(myWonderland getNamespace at: myName ifAbsent: [ nil ])
					ifNotNil: [ myName _ myWonderland uniqueNameFrom: myName ].

				(myWonderland getNamespace at: myName put: self).
				]
		ifFalse: [
				myName _ parentClass uniqueNameFrom: myName.		
				classList remove: parentClass.
				myParent addInstanceVarNamed: myName withValue: self.
				(myParent class) compile: (myName , '
											^ ' , myName, '.').
				classList addLast: (myParent class).
				].

	composite _ newComposite.

	"Now update the actor browser"
	myWonderland getEditor updateActorBrowser.