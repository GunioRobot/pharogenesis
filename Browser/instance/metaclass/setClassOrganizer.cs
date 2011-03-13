setClassOrganizer
	"Install whatever organization is appropriate"
	classOrganizer _ nil.
	metaClassOrganizer _ nil.
	classListIndex = 0 ifTrue: [^ self].
	metaClassIndicated
		ifTrue: [metaClassOrganizer _ self selectedClass class organization]
		ifFalse: [classOrganizer _ self selectedClass organization]