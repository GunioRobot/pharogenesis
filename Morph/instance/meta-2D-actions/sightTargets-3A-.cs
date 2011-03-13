sightTargets: event 
	"Return the potential targets for the receiver.  
	This is derived from Morph>>potentialEmbeddingTargets."
	| bullseye |
	owner
		ifNil: [^ #()].
	bullseye := Point fromUserWithCursor: Cursor target.
	self targetFromMenu: (self potentialTargetsAt: bullseye) asKnownNameMenu popupAt: bullseye