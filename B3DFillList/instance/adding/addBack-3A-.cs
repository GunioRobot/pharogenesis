addBack: aFace
	"Add the given face as a non-front face (e.g., insert it after the front face).
	Make sure that the receiver stays sorted by the minimal z values of faces."
	| minZ midZ face |
	firstFace == nil ifTrue:[^self error:'Inserting a back face with no front face'].
	minZ _ aFace minZ.
	"Quick optimization for insertion at end"
	(firstFace == lastFace or:[minZ >= lastFace minZ]) ifTrue:[^self addLast: aFace].
	"Try an estimation for how to search"
	midZ _ (firstFace nextFace minZ + lastFace minZ) * 0.5.
	minZ <= midZ ifTrue:[
		"Search front to back"
		face _ firstFace nextFace.
		[face minZ < minZ] whileTrue:[face _ face nextFace].
	] ifFalse:[
		"Search back to front"
		face _ lastFace prevFace. "Already checked for lastFace minZ < face minZ"
		[face minZ > minZ] whileTrue:[face _ face prevFace].
		face _ face nextFace.
	].
	self insert: aFace before: face.