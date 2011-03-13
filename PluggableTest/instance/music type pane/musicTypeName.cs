musicTypeName
	"Answer the name of the currently selected music type, or nil if no music type is selected."

	(musicTypeIndex between: 1 and: musicTypeList size)
		ifTrue: [^ musicTypeList at: musicTypeIndex]
		ifFalse: [^ nil].
