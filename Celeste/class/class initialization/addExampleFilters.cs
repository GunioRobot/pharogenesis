addExampleFilters
	"add some example named filters"
	"Celeste addExampleFilters"
	NamedFilters at: 'squeak' put: (CelesteParticipantFilter forParticipant: 'squeak-dev@lists.squeakfoundation.org').

	NamedFilters at: 'personal' put: (CelesteCodeFilter new code:
'"substitute email1, etc., with your email addresses"
m participantHas: #(''email1'' ''email2'')').

	NamedFilters at: 'new' put: (CelesteCategoryFilter forCategory: 'new').