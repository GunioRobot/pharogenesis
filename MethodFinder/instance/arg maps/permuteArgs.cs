permuteArgs 
	"Run through ALL the permutations.  First one was as presented."

	data first size <= 1 ifTrue: [^ false].	"no other way"
	mapList ifNil: [self makeAllMaps].
	mapStage _ mapStage + 1.
	mapStage > mapList size ifTrue: [^ false].
	argMap _ mapList at: mapStage.
	self mapData.
	^ true
	