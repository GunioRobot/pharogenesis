rootsIncludingBlockMethods
	"Return a new roots array with more objects.  (Caller should store into rootArray.) Any CompiledMethods that create blocks will be in outPointers if the block is held outside of this segment.  Put such methods into the roots list.  Then ask for the segment again."

| extras myClasses gotIt |
userRootCnt ifNil: [userRootCnt _ arrayOfRoots size].
extras _ OrderedCollection new.
myClasses _ OrderedCollection new.
arrayOfRoots do: [:aRoot | aRoot class class == Metaclass ifTrue: [
					myClasses add: aRoot]].
myClasses isEmpty ifTrue: [^ nil].	"no change"
outPointers do: [:anOut | 
	anOut class == CompiledMethod ifTrue: [
		"specialized version of who"
		gotIt _ false.
		myClasses detect: [:class |
			class selectorsDo: [:sel |
				(class compiledMethodAt: sel) == anOut 
					ifTrue: [extras add: anOut.  gotIt _ true]].
			gotIt] 
			ifNone: []
		].
	anOut _ nil].
extras _ extras select: [:ea | (arrayOfRoots includes: ea) not].
extras isEmpty ifTrue: [^ nil].	"no change"
^ arrayOfRoots, extras