transposeParts
	"The receiver's orientation has just been changed from vertical to horizontal or vice-versa.  One could imagine trying to be smart about transposition, though the variety of possibilities is daunting."
	self flag: #deferred.
	"edgeToAdhereTo == #vertical ifTrue: ..."