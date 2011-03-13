rootsIncludingPlayers
	"Players have been removed from Morphs, this method could now more accurately be renamed rootsIncludingMorphs"
	"Return a new roots array with more objects.  (Caller should store into rootArray.) The world morph gets all its submorphs put into the Roots array.  Then ask for the segment again."
	
	"I'm not sure if the usage of this method, just doing refactoring....
	Is it a bug that if you have more than one WorldMorph/Project/Presenter in roots, only the submorphs of the (originally final, now first due to use of detect: instead of do:) ones world will be added? "
| morphs existing worldAccessRoot |
	userRootCnt ifNil: [userRootCnt := arrayOfRoots size].

	worldAccessRoot := arrayOfRoots detect: [:one |
		(one isMorph and: [one isWorldMorph])  or: [
		{Presenter. Project} contains: [:class | one isKindOf: class]]]
								 ifNone: [^nil].

	worldAccessRoot world ifNotNil: [:world |
		morphs := IdentitySet new: 400.
		world allMorphsInto: morphs.].
	
	existing := arrayOfRoots asIdentitySet.
	morphs := morphs asOrderedCollection reject: [ :each | existing includes: each].
	morphs isEmpty ifTrue: [^ nil].	"no change"
	worldAccessRoot := morphs := nil.
^ arrayOfRoots, morphs	"will contain multiples of some, but reduced later"
