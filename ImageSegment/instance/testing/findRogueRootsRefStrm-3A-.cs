findRogueRootsRefStrm: rootArray
	"This is a tool to track down unwanted pointers into the segment.  If we don't deal with these pointers, the segment turns out much smaller than it should.  These pointers keep a subtree of objects out of the segment.
1) assemble all objects that should be in the segment by using SmartReference Stream and a dummyReference Stream.  Put in a Set.
2) Remove the roots from this list.  Ask for senders of each.  Of the senders, forget the ones that are in the segment already.  Keep others.  The list is now all the 'incorrect' pointers into the segment."

| dummy goodInSeg inSeg ok pointIn |
dummy _ ReferenceStream on: (DummyStream on: nil).
		"Write to a fake Stream, not a file"
rootArray do: [:root |
	dummy rootObject: root.	"inform him about the root"
	dummy nextPut: root.
	].
inSeg _ dummy references keys.
dummy _ nil.   Smalltalk garbageCollect.  "dump refs dictionary"
rootArray do: [:each | inSeg remove: each ifAbsent: []].
	"want them to be pointed at from outside"
pointIn _ IdentitySet new: 500.
goodInSeg _ IdentitySet new: 2000.
inSeg do: [:obj |
	ok _ obj class isPointers.
	obj class == Color ifTrue: [ok _ false].
	obj class == TranslucentColor ifTrue: [ok _ false].
	obj class == Array ifTrue: [obj size = 0 ifTrue: [ok _ false]].
		"shared #() in submorphs of all Morphs"
	ok ifTrue: [goodInSeg add: obj]].
goodInSeg do: [:ob |
		pointIn addAll: (Smalltalk pointersTo: ob except: #())].
inSeg do: [:each | pointIn remove: each ifAbsent: []].
rootArray do: [:each | pointIn remove: each ifAbsent: []].
pointIn remove: inSeg array ifAbsent: [].
pointIn remove: goodInSeg array ifAbsent: [].
pointIn remove: pointIn array ifAbsent: [].
self halt: 'Examine local variables pointIn and inSeg'.
^ pointIn