makeTriangleFans
	"Re-arrange the triangles so that they represent triangle fans."
	| vtxDict avgFacesPerVertex todo done maxShared maxSharedIndex newOrder sharedAssoc |
	"Compute the average size of faces per vertex (strange measure isn't it ;-)"
	avgFacesPerVertex _ faces size // vertices size + 3. "So we cover 99% of all cases"
	"vtxDict contains vertexIndex->(OrderedCollection of: IndexedFace)"
	vtxDict _ OrderedCollection new: vertices size.
	"Add all the vertex indexes. The set is larger than necessary to avoid collisions."
	1 to: vertices size do:[:i| vtxDict add: i -> (IdentitySet new: avgFacesPerVertex * 3)].
	"Go over all faces and add the face to all its vertices. Also store the faces in the toGo list."
	todo _ IdentitySet new: faces size * 3.
	done _ IdentitySet new: faces size * 3.
	faces do:[:iFace| 
		todo add: iFace.
		(vtxDict at: iFace p1Index) value add: iFace.
		(vtxDict at: iFace p2Index) value add: iFace.
		(vtxDict at: iFace p3Index) value add: iFace].
	"Now start creating the fans"
	[todo isEmpty] whileFalse:[
		"Let's assume that this method is not called in real-time 
		and spend some time to find the vertex with most shared faces"
		maxShared _ 0.
		maxSharedIndex _ nil.
		vtxDict doWithIndex:[:assoc :index| assoc value size > maxShared
			ifTrue:[maxShared _ assoc value size.
					maxSharedIndex _ index]].
		maxSharedIndex = nil ifTrue:[^self error:'No shared vertices found'].
		"Now re-arrange the faces around the shared vertex"
		sharedAssoc _ vtxDict at: maxSharedIndex.
		newOrder _ self reArrangeFanFaces: sharedAssoc value around: sharedAssoc key from: todo into: done.
		"Remove re-arranged faces"
		newOrder do:[:iFace|
			(done includes: iFace) ifTrue:[self halt].
			todo remove: iFace.
			done add: iFace.
			(vtxDict at: iFace p1Index) value remove: iFace ifAbsent:[].
			(vtxDict at: iFace p2Index) value remove: iFace ifAbsent:[].
			(vtxDict at: iFace p3Index) value remove: iFace ifAbsent:[]].
		false ifTrue:[
		"Remove the shared index if no more faces left."
		sharedAssoc value isEmpty ifTrue:[
			vtxDict swap: maxSharedIndex with: vtxDict size.	"Optimized removal ;-)"
			vtxDict removeLast].
		].
	].