replace: original withNew: obj class: class length: length trace: traceBlock write: writeBlock
	| oop objpos headers type hash |
	"We assign file space for an object, replacing original.
	Only does something when original has not been assigned a new oop yet.  
	Length is the instance vars and variable portion in longs.
	Class is not included in length.
	Special objects come here for an oop, and do no tracing or writing.
	To trace and write their fields later, do NOT use this method."  
	oop_ self mapAt: original.
	oop = UnassignedOop ifFalse:
		["Original has already been assigned a new oop or clamped."
		^ self].

	oop_ self mapAt: obj.
	oop = UnassignedOop ifFalse:
		["replacement has already been assigned a new oop or clamped."
		^ self].

	"Write header and remember new oop in map. Headers must be derived from new object, since its class and format affect the values."
	hash _ (hashGenerator next * 16rFFF asFloat) asInteger.
	headers _ self headersFor: obj withHash: hash.
	file position: maxOop + imageHeaderSize.
	headers do: [:h | self write4Bytes: h].
	maxOop _ maxOop + (headers size-1*4).		"New oop points at header word"

	"log thenew object as both the original and itself"
	self mapAt: obj put: maxOop with: hash.
	self mapAt: original put: maxOop with: hash.
	objpos _ maxOop + imageHeaderSize.		"file position"
length > 20 ifTrue: [maxOop printString, ' ' displayAt: 0@0].

	"Write blank data, advancing to next object position"
	maxOop _ maxOop + (length+1*4).	"ready for next object"
	file nextPutAll: (ByteArray new: length*4 withAll: 0).

	"There is a good chance that we might need to substitute the class of the original object with the class of 'obj', so make sure both classes are properly traced"
	traceBlock notNil ifTrue: [self trace: original class. self trace: class.  traceBlock value].
	(headers size > 1 and: [(headers at: headers size-1) < 0])
		ifTrue: ["rewrite class word if not known before"
				file position: objpos-4.
				type _ (headers at: headers size-1) bitAnd: 3.
				self write4Bytes: (self mapAt: class) + type.
				self write4Bytes: (headers at: headers size) "faster to write than skip"]
		ifFalse: ["Had no class header, or was already valid"
				file position: objpos+4].
	"Now positioned after header, before data..."

	writeBlock value.	"No allocation of new oops is allowed in here!"

	"Consistency check"
	file position = (objpos + (length+1*4)) ifFalse:
		["writeBlock did not leave us at end of object"
		self error: 'reposition error'.
		"Maybe copied an object without putting it in holder,
		so it got freed and became something else of a different size"]