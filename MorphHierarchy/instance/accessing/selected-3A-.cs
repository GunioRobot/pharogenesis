selected: aMorphListItemWrapper 
	"Change the selected object"
	| newSelection |
	aMorphListItemWrapper isNil
		ifTrue: [^ self].
	newSelection := aMorphListItemWrapper withoutListWrapper.
	newSelection == World selectedObject
		ifTrue: [newSelection removeHalo]
		ifFalse: [newSelection addHalo].
	self changed: #selected