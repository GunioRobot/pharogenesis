allSelectorsUnderstood
	"Answer a list of all selectors understood by instances of the receiver"

	| aList |
	self deprecated: 'Use allSelectors instead.'.
	aList _ OrderedCollection new.
	self withAllSuperclasses do:
		[:aClass | aList addAll: aClass selectors].
	^ aList asSet asArray

"SketchMorph allSelectorsUnderstood size"