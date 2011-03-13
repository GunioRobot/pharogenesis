fixGlobalReferences
	"Fix all the references to globals which are now outdated.
	Care must be taken that we do not accidentally 'fix' dangerous stuff."
	| oldClasses newClasses condition any |
	classMap == nil ifTrue:[^self].
	(self retryWithGC: [condition _ classMap anySatisfy: [:any0 | any _ any0. any0 _ nil. any notNil and:[any
isObsolete]]. any_nil. condition]
		until:[:obsRef| obsRef = false])
		ifFalse:[^self]. "GC cleaned up the remaining refs"
	"Collect the old and the new refs"
	oldClasses _ OrderedCollection new.
	newClasses _ OrderedCollection new.
	classMap keysAndValuesDo:[:new :old|
		old == nil ifFalse:[
			newClasses add: new.
			oldClasses add: old]].
	oldClasses isEmpty ifTrue:[^self]. "GC cleaned up the rest"

	"Now fix all the known dangerous pointers to old classes by creating
	copies of those still needed. Dangerous pointers should come only
	from obsolete subclasses (where the superclass must be preserved)."
	self fixObsoleteReferencesTo: oldClasses.

	"After this has been done fix the remaining references"
	progress == nil ifFalse:[progress value: 'Fixing references to
globals'].
	"Forward all old refs to the new ones"
	(oldClasses asArray) elementsForwardIdentityTo: (newClasses asArray).
	"Done"