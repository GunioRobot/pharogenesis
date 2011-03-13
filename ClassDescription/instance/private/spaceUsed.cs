spaceUsed
	"Answer a rough estimate of number of bytes in this class and its metaclass"
	| space method |
	space _ 0.
	self selectorsDo:
		[:sel | space _ space + 16.  "dict and org'n space"
		method _ self compiledMethodAt: sel.
		space _ space + (method size + 6 "hdr + avg pad").
		method literals do:
			[:lit | ((lit isMemberOf: Symbol) or: [lit isMemberOf: SmallInteger]) ifFalse:
				[(lit isMemberOf: String) ifTrue: [space _ space + (lit size+6)].
				(lit isMemberOf: Array) ifTrue: [space _ space + (lit size+1*4)]]]].
	(self isMemberOf: Metaclass)
		ifTrue: [^ space]
		ifFalse: [^ space + self class spaceUsed]