shortPrint: oop
	| name classOop |
	(self isIntegerObject: oop) ifTrue: [^ '=' , (self integerValueOf: oop) printString , ' (' , (self integerValueOf: oop) hex , ')'].
	classOop _ self fetchClassOf: oop.
	(self sizeBitsOf: classOop) =16r20 ifTrue: [^ 'class ' , (self nameOfClass: oop)].
	name _ self nameOfClass: classOop.
	name size = 0 ifTrue: [name _ '??'].
	name = 'String' ifTrue: [^ (self stringOf: oop) printString].
	name = 'Symbol' ifTrue: [^ '#' , (self stringOf: oop)].
	name = 'Character' ifTrue: [^ '=' ,
			(Character value: (self integerValueOf: (self fetchPointer: 0 ofObject: oop))) printString].
	name = 'UndefinedObject' ifTrue: [^ 'nil'].
	name = 'False' ifTrue: [^ 'false'].
	name = 'True' ifTrue: [^ 'true'].
	name = 'Float' ifTrue: [^ '=' , (self floatValueOf: oop) printString].
	name = 'Association' ifTrue: [^ '(' ,
				(self shortPrint: (self longAt: oop + BaseHeaderSize)) ,
				' -> ' ,
				(self longAt: oop + BaseHeaderSize + 4) hex8 , ')'].
	('AEIOU' includes: name first)
		ifTrue: [^ 'an ' , name]
		ifFalse: [^ 'a ' , name]