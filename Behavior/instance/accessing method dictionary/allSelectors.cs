allSelectors
	"Answer all selectors understood by instances of the receiver"

	| coll |
	coll _ OrderedCollection new.
	self withAllSuperclasses do:
		[:aClass | coll addAll: aClass selectors].
	^ coll asIdentitySet