visibleMorphsIn: aRectangle
	"Return the front-most morphs that fill this rectangle.
	Designed to avoid drawing fully occluded regions"
	| visibleMorphs |
	visibleMorphs _ OrderedCollection new: 50.
	self morphsIntersecting: aRectangle
		do: [:m | (m drawOnFills: aRectangle) ifTrue: [visibleMorphs reset].
			visibleMorphs addLast: m].
	^ visibleMorphs