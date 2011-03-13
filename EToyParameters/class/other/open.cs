open
	"EToyParameters open"
	| aWorld ctls |
	aWorld _ WorldMorph new.
	ctls _ self new initializeIn: aWorld.
	MorphWorldView openOn: aWorld label: 'EToy Controls' model: ctls