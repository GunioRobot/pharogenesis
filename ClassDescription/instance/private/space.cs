space
	"Answer a rough estimate of number of objects in this class and its metaclass"
	| objs words method metaSpace |
	objs _ words _ 0.
	self selectorsDo:
		[:sel | objs_ objs+1.
		method _ self compiledMethodAt: sel.
		words _ words + (method size+1//2) + 2 + 4 "dict and org'n space".
		method literals do:
			[:lit | (lit isMemberOf: String) ifTrue:
				[words _ words+2+(lit size+1//2).
				objs _ objs+1]]].
	(self isMemberOf: Metaclass) ifFalse:
		[metaSpace _ self class space.
		objs _ objs + metaSpace first.
		words _ words + metaSpace last].
	^ Array with: objs with: words