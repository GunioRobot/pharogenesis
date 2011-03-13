showMenu
	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addList: #(
		('remove'			removeEntry)
		('rename'			renameEntry)
		('repaint'			repaintEntry)
		-
		('find...'			findEntry)
		-
		('hand me one'		handMeOne)).
	aMenu popUpInWorld: self currentWorld.
