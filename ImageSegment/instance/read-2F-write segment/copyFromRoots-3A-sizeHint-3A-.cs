copyFromRoots: aRootArray sizeHint: segSizeHint
	"Copy a tree of objects into a WordArray segment.  The copied objects in the segment are not in the normal Squeak space.  If this method yields a very small segment, it is because objects just below the roots are pointed at from the outside.  (See findRogueRootsImSeg: for a *destructive* diagnostic of who is pointing in.)"
	| segmentWordArray outPointerArray segSize rootSet uniqueRoots |
	aRootArray ifNil: [self errorWrongState].
	(Symbol classPool at: #SelectorTables) first first class == WeakArray ifTrue: [
		Symbol useArrayTables].	"Hold onto Symbols.  Done only once."
	rootSet _ IdentitySet new: 150.
	uniqueRoots _ OrderedCollection new.
	1 to: aRootArray size do: [:ii |	"Don't include any roots twice"
		(rootSet includes: (aRootArray at: ii)) 
			ifFalse: [
				uniqueRoots addLast: (aRootArray at: ii).
				rootSet add: (aRootArray at: ii)]
			ifTrue: [userRootCnt ifNotNil: ["adjust the count"
						ii <= userRootCnt ifTrue: [userRootCnt _ userRootCnt - 1]]]].
	arrayOfRoots _ uniqueRoots asArray.
	rootSet _ uniqueRoots _ nil.	"be clean"
	userRootCnt ifNil: [userRootCnt _ arrayOfRoots size].
	arrayOfRoots do: [:aRoot | (aRoot respondsTo: #indexIfCompact) ifTrue: [
		aRoot indexIfCompact > 0 ifTrue: [
			self error: 'Compact class ', aRoot name, ' cannot be a root']].
		aRoot _ nil].	"clean up"
	outPointers _ nil.	"may have used this instance before"
	segSize _ segSizeHint > 0 ifTrue: [segSizeHint *3 //2] ifFalse: [50000].

	["Guess a reasonable segment size"
	segmentWordArray _ WordArrayForSegment new: segSize.
	[outPointerArray _ Array new: segSize // 20] ifError: [
		state _ #tooBig.  ^ self].
	Smalltalk garbageCollect.	"Remove this when everyone is using the new VM"
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
