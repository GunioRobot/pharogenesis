color: aColor
	"Change the color of the actor"
	self undoOnTop: UndoColorChange using:[myActor getColor].
	myActor setColorVector: aColor asB3DColor