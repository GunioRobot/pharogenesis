reArrangeFanFaces: sharedFaces around: maxSharedIndex from: todo into: done
	"Re-arrange the faces in sharedFaces to form a triangle fan.
	Avoid inplace-reversal of the triangles in doneList -- they have been arranged already"
	| out next nextIndex prevIndex index |
	out _ OrderedCollection new: sharedFaces size * 2.
	next _ sharedFaces detect:[:any| true].
	sharedFaces remove: next.
	out addLast: next.
	nextIndex _ next p1Index.
	nextIndex = maxSharedIndex ifTrue:[nextIndex _ next p2Index].
	prevIndex _ next p3Index.
	(prevIndex = maxSharedIndex) ifTrue:[prevIndex _ next p2Index].
	"Search forward"
	[next _ sharedFaces detect:[:iFace| iFace includesIndex: nextIndex] ifNone:[nil].
	next notNil] whileTrue:[
		sharedFaces remove: next.
		out addLast: next.
		index _ next p1Index.
		(index = maxSharedIndex or:[index = nextIndex]) ifTrue:[
			index _ next p2Index.
			(index = maxSharedIndex or:[index = nextIndex]) 
				ifTrue:[index _ next p3Index]].
		nextIndex _ index].
	"Search backwards"
	nextIndex _ prevIndex.
	[next _ sharedFaces detect:[:iFace| iFace includesIndex: nextIndex] ifNone:[nil].
	next notNil] whileTrue:[
		sharedFaces remove: next.
		out addFirst: next.
		index _ next p1Index.
		(index = maxSharedIndex or:[index = nextIndex]) ifTrue:[
			index _ next p2Index.
			(index = maxSharedIndex or:[index = nextIndex]) 
				ifTrue:[index _ next p3Index]].
		nextIndex _ index].
	^out