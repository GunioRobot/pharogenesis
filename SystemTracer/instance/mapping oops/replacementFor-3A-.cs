replacementFor: obj
	"return the replacement class, if there is one"
	obj class == SmallInteger ifTrue: [^ nil].
	^ replacementClasses at: obj ifAbsent:[nil]