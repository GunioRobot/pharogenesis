writePointerField: obj 
	| newOop |
	obj class == SmallInteger ifTrue: 
		[obj >= 0 ifTrue: [newOop _ obj * 2 + 1]
				ifFalse: [newOop _ (16r80000000 + obj) * 2 + 1].
		self write4Bytes: newOop.
		^ obj].		

	"normal pointers"
	(newOop _ self mapAt: obj) = Clamped
		ifTrue: ["If object in this field is not being traced, put out nil."
				self write4Bytes: NewNil]
		ifFalse: [self write4Bytes: newOop]