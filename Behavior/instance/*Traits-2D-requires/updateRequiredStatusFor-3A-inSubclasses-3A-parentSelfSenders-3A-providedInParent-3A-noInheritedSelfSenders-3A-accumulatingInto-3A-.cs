updateRequiredStatusFor: selector inSubclasses: someClasses parentSelfSenders: inheritedSelfSenders providedInParent: inheritedMethod noInheritedSelfSenders: noInheritedBoolean accumulatingInto: requiringClasses 
	"Updates the requirements cache to reflect whether selector is required in this class and all of its subclasses. The parameter inheritedSelfSenders is a subset of the methods in the parent of this class that are known to self-send selector. providedBoolean indicates whether selector is provided in the parent. noInheritedBoolean is true if no self-senders could be found in the superclass.
	See Nathanael Schärli's PhD for more details."

	"Remove from the inherited selfSenders methods that are potentially unreachable."

	| selfSenders m relevantMethod required lookedForInheritedSelfSenders |
	lookedForInheritedSelfSenders := false.
	selfSenders := inheritedSelfSenders 
				reject: [:each | self includesSelector: each].

	"Check whether the method is provided."
	m := self compiledMethodAt: selector ifAbsent: [nil].
	relevantMethod := m ifNotNil: [m] ifNil: [inheritedMethod].
	relevantMethod 
		ifNotNil: [required := relevantMethod isSubclassResponsibility or: [
					relevantMethod isDisabled or: [
						relevantMethod isExplicitlyRequired]]]
		ifNil: ["If there are non-overridden inherited selfSenders we know that it must be
		required. Otherwise, we search for self-senders."

			selfSenders isEmpty 
				ifTrue: 
					[selfSenders := self 
								findSelfSendersOf: selector
								unreachable: IdentitySet new
								noInheritedSelfSenders: noInheritedBoolean.
					lookedForInheritedSelfSenders := true].
			required := selfSenders notEmpty].

	required ifTrue: [requiringClasses add: self].

	"Do the same for all subclasses."
	self subclassesDo: 
			[:each | 
			(someClasses includes: each) 
				ifTrue: 
					[each 
						updateRequiredStatusFor: selector
						inSubclasses: someClasses
						parentSelfSenders: selfSenders
						providedInParent: relevantMethod
						noInheritedSelfSenders: (lookedForInheritedSelfSenders and: [selfSenders isEmpty])
						accumulatingInto: requiringClasses]].
	^requiringClasses