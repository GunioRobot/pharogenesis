priority
	"Return the priority for this event"
	type == #start ifTrue:[^3]. "first insert new segments"
	type == #cross ifTrue:[^2]. "then process intersections"
	type == #end ifTrue:[^1]. "then remove edges"
	^self error:'Unknown type'