swapOutProjects  "ImageSegment swapOutProjects"  
	"Swap out segments for all projects other than the current one."

	| spaceLeft newSpaceLeft |
	spaceLeft _ Smalltalk garbageCollect.
	Project allSubInstances doWithIndex:
		[:p :i | p == Project current ifFalse:
			[Transcript cr; cr; nextPutAll: p name.
			(ImageSegment new copyFromRoots: (Array with: p) sizeHint: 0)
				extract; writeToFile: 'project' , i printString.
			newSpaceLeft _ Smalltalk garbageCollect.
			Transcript cr; print: newSpaceLeft - spaceLeft; endEntry.
			spaceLeft _ newSpaceLeft]].