hasReplacement: obj
	"See if obj will be replaced in the new system."
	obj class == SmallInteger ifTrue: [^ false].
	^ replacementClasses includes: obj 