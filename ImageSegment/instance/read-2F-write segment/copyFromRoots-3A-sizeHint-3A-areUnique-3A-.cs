copyFromRoots: aRootArray sizeHint: segSizeHint areUnique: areUnique
	"Copy a tree of objects into a WordArray segment.  The copied objects in the segment are not in the normal Squeak space.  
	[1] For exporting a project.  Objects were enumerated by ReferenceStream and aRootArray has them all.
	[2] For exporting some classes.  See copyFromRootsForExport:. (Caller must hold Symbols, or they will not get registered in the target system.)
	[3] For 'local segments'.  outPointers are kept in the image.
	If this method yields a very small segment, it is because objects just below the roots are pointed at from the outside.  (See findRogueRootsImSeg: for a *destructive* diagnostic of who is pointing in.)"
	| segmentWordArray outPointerArray segSize rootSet uniqueRoots |
	aRootArray ifNil: [self errorWrongState].
	uniqueRoots _ areUnique 
		ifTrue: [aRootArray]
		ifFalse: [rootSet _ IdentitySet new: aRootArray size * 3.
			uniqueRoots _ OrderedCollection new.
			1 to: aRootArray size do: [:ii |	"Don't include any roots twice"
				(rootSet includes: (aRootArray at: ii)) 
					ifFalse: [
						uniqueRoots addLast: (aRootArray at: ii).
						rootSet add: (aRootArray at: ii)]
					ifTrue: [userRootCnt ifNotNil: ["adjust the count"
								ii <= userRootCnt ifTrue: [userRootCnt _ userRootCnt - 1]]]].
			uniqueRoots].
	arrayOfRoots _ uniqueRoots asArray.
	rootSet _ uniqueRoots _ nil.	"be clean"
	userRootCnt ifNil: [userRootCnt _ arrayOfRoots size].
	arrayOfRoots do: [:aRoot | 
		aRoot indexIfCompact > 0 ifTrue: [
			self error: 'Compact class ', aRoot name, ' cannot be a root'].
		aRoot _ nil].	"clean up"
	outPointers _ nil.	"may have used this instance before"
	segSize _ segSizeHint > 0 ifTrue: [segSizeHint *3 //2] ifFalse: [50000].

	["Guess a reasonable segment size"
	segmentWordArray _ WordArrayForSegment new: segSize.
	[outPointerArray _ Array new: segSize // 20] ifError: [
		state _ #tooBig.  ^ self].
	"Smalltalk garbageCollect."
	(self storeSegmentFor: arrayOfRoots
					into: segmentWordArray
					outPointers: outPointerArray) == nil]
		whileTrue:
			["Double the segment size and try again"
			segmentWordArray _ outPointerArray _ nil.
			segSize _ segSize * 2].
	segment _ segmentWordArray.
	outPointers _ outPointerArray.
	state _ #activeCopy.
	endMarker _ segment nextObject. 	"for enumeration of objects"
	endMarker == 0 ifTrue: [endMarker _ 'End' clone].
