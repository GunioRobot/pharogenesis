veryDeepFixupWith: deepCopier
	| list |
	"If target and arguments fields were weakly copied, fix them here.  If they were in the tree being copied, fix them up, otherwise point to the originals!!"

	super veryDeepFixupWith: deepCopier.
	otherProperties ifNotNil: [
		list _ self copyWeakly.	"Properties whose values are only copied weakly"
		"replace those values if they were copied via another path"
		list do: [:pp | 
			(otherProperties at: pp ifAbsent: [nil]) ifNotNil: [
				otherProperties at: pp put: 
					(deepCopier references at: (otherProperties at: pp) 
									ifAbsent: [(otherProperties at: pp)])]]].

