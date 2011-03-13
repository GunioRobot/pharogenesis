stdBorderColor 

	"several choices of how to do the border"
	self class noTileColor
		ifTrue: [^ "color" Color transparent]
		ifFalse: [^ "color darker" Color transparent]