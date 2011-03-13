findRootsAndRoutes
	"Based on the 
	1. target classes (ones considered interesting by our clients) and the 
	2. modifiedBehaviors (ones we are told might have changed), 
	decide the 
	A. rootClasses (superclasses of target classes that include methods from modifiedBehaviors) 
	B. classesToUpdate (classes that may have been affected AND are on an inheritance path between a root class and a target class, will be updated by the algorithm. This includes the every target class that may have been affected).
	C. mapping from root classes to its classesToUpdate."

	| highestSuperclassOfCurrentTarget modifiedClasses |
	classesToUpdate := IdentitySet new.
	rootClasses := IdentitySet new.
	modifiedClasses := (modifiedBehaviors gather: [:mb | mb classesComposedWithMe]) asIdentitySet.
	targetClasses do: [:currentTargetClass | 
		highestSuperclassOfCurrentTarget := nil.
		currentTargetClass withAllSuperclassesDo: [:sc | 
			(modifiedClasses includes: sc) ifTrue: 
				[highestSuperclassOfCurrentTarget := sc.
				self noteRoot: sc possiblyAffected: currentTargetClass]].
			highestSuperclassOfCurrentTarget ifNotNil: [:highestRoot | 
				self addUpdatePathTo: currentTargetClass from: highestRoot]]