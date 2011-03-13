sightWorldTargets: event 
	"Return the potential targets for the receiver.  
	This is derived from Morph>>potentialEmbeddingTargets."
	| bullseye myWorld |
	myWorld := self world
		ifNil: [^ #()].
	bullseye := Point fromUserWithCursor: Cursor target.
	self targetFromMenu: ( myWorld morphsAt: bullseye) asKnownNameMenu popupAt: bullseye