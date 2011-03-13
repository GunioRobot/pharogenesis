copyStateFrom: aPlayer
	"Just a place-holder for the present: clear out scripts; until we also clear out the method dictionary, this is an inconsistency.  Also, need attention to inst vars"

	self class copyStateFrom: aPlayer class.
	self copyAddedStateFrom: aPlayer.  "the inst vars added by him"
	self flag: #deferred.  "Doesn't yet deal with stuff stored on the morph side"