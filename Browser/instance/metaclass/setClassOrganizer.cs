setClassOrganizer
	"Install whatever organization is appropriate"
	| theClass |
	classOrganizer _ nil.
	metaClassOrganizer _ nil.
	classListIndex = 0 ifTrue: [^ self].
	theClass _ self selectedClass ifNil: [ ^self ].
	classOrganizer _ theClass organization.
	metaClassOrganizer _ theClass classSide organization.