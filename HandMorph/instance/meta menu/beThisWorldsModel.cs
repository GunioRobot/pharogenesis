beThisWorldsModel

	self world setModel: argument.
	argument model: nil slotName: nil.	"A world's model cannot have another model"