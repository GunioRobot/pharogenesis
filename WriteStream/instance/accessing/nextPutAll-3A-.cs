nextPutAll: aCollection
	| newEnd |

	collection class == aCollection class ifFalse: [
		^super nextPutAll: aCollection ].

	newEnd _ position + aCollection size.
	newEnd > writeLimit ifTrue: [
		collection _ collection,
			(collection species new: (newEnd - writeLimit + (collection size max: 20)) ).
		writeLimit _ collection size ].

	collection replaceFrom: position+1 to: newEnd  with: aCollection.
	position _ newEnd.