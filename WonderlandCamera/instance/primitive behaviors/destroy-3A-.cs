destroy: t1 
	| t2 t3 t4 |
	t4 _ OrderedCollection new.
	t3 _ self getAllChildren.
	t3
		do: [:t5 | t5 isFirstClass
				ifTrue: [t4
						addLast: (UndoParentChange newFor: t5 from: t5 getParent).
					t5 reparentTo: self getParent]].
	self removeFromScene.
	myMorph delete.
	t2 _ myWonderland getCameraList.
	t2 remove: self.
	t4
		addLast: (UndoAction
				new: [myMorph openInWorld.
					myWonderland getScene addChild: self.
					t2 addLast: self]).
	myWonderland getUndoStack
		push: (UndoChangeList new setChangeList: t4)