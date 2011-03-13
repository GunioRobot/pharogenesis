potentialTargetsAt: aPoint 
	"Return the potential targets for the receiver.  
	This is derived from Morph>>potentialEmbeddingTargets."
	owner
		ifNil: [^ #()].
	^ owner
		morphsAt: aPoint
		