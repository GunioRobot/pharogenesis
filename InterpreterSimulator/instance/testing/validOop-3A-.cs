validOop: oop
	"halt if invalid active object"
	(oop bitAnd: 1) = 1 ifTrue: [^ self].
	(oop bitAnd: 3) = 0 ifFalse: [self halt].
	oop >= endOfMemory ifTrue: [self halt].
	"could test if within the first large freeblock"
	(self longAt: oop) = 4 ifTrue: [self halt].
	(self headerType: oop) = 2 ifTrue: [self halt].	"free object"