hasClamped: obj
	"See if obj will be a SmallInteger in the new system."
	obj class == SmallInteger ifTrue: [^ true].
	^ (self mapAt: obj) = Clamped