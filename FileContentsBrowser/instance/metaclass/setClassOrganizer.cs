setClassOrganizer
	"Install whatever organization is appropriate"
	| theClass |
	classOrganizer _ nil.
	metaClassOrganizer _ nil.
	classListIndex = 0 ifTrue: [^ self].
	classOrganizer _ (theClass _ self selectedClass) organization.
	metaClassOrganizer _ theClass metaClass organization.
