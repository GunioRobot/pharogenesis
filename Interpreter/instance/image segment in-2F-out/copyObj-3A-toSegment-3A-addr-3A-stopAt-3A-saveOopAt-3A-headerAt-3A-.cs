copyObj: oop toSegment: segmentWordArray addr: lastSeg stopAt: stopAddr saveOopAt: oopPtr headerAt: hdrPtr
	"Copy this object into the segment beginning at lastSeg.
	Install a forwarding pointer, and save oop and header.
	Fail if out of space.  Return the next segmentAddr if successful."

	"Copy the object..."
	| extraSize bodySize hdrAddr |
	successFlag ifFalse: [^ lastSeg].
	extraSize _ self extraHeaderBytes: oop.
	bodySize _ self sizeBitsOf: oop.
	(lastSeg + extraSize + bodySize) >= stopAddr
		ifTrue: [^ self primitiveFail].
	self transfer: extraSize + bodySize // 4  "wordCount"
		from: oop - extraSize
		to: lastSeg+4.

	"Clear root and mark bits of all headers copied into the segment"
	hdrAddr _ lastSeg+4 + extraSize.
	self longAt: hdrAddr put: ((self longAt: hdrAddr) bitAnd: AllButRootBit - MarkBit).

	self forward: oop to: (lastSeg+4 + extraSize - segmentWordArray)
		savingOopAt: oopPtr andHeaderAt: hdrPtr.

	"Return new end of segment"
	^ lastSeg + extraSize + bodySize