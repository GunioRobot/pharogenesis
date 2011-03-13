updateRequiredStatusFor: selector  inSubclasses: someClasses parentSelfSenders: inheritedSelfSenders providedInParent: providedBoolean noInheritedSelfSenders: noInheritedBoolean
	"Updates the requirements cache to reflect whether selector is required in this class and all of its subclasses. The parameter inheritedSelfSenders is a subset of the methods in the parent of this class that are known to self-send selector. providedBoolean indicates whether selector is provided in the parent. noInheritedBoolean is true if no self-senders could be found in the superclass.
	See Nathanael Sch䲬i's PhD for more details."

	| selfSenders provided m |
	"Remove from the inherited selfSenders methods that are potentially unreachable."
	selfSenders := inheritedSelfSenders reject: [:each | self includesSelector: each].
	
	"Check whether the method is provided."
	m := self compiledMethodAt: selector ifAbsent: [nil].
	providedBoolean ifTrue: [
		provided := m isNil or: [m isDisabled not and: [m isExplicitlyRequired not and: [m isSubclassResponsibility not]]].
	] ifFalse: [
		provided := m notNil and: [m isProvided].
	].

	provided ifTrue: [
		"If it is provided, it cannot be required."
		self setRequiredStatusOf: selector to: false.
	] ifFalse: [
		"If there are non-overridden inherited selfSenders we know that it must be
		required. Otherwise, we search for self-senders."
		selfSenders isEmpty ifTrue: [selfSenders := self findSelfSendersOf: selector unreachable: IdentitySet new noInheritedSelfSenders: noInheritedBoolean].
		self setRequiredStatusOf: selector to: selfSenders notEmpty.
	].

	"Do the same for all subclasses."
	self subclassesDo: [:each |
		 (someClasses includes: each) ifTrue: 
			[each updateRequiredStatusFor: selector  
				inSubclasses: someClasses 
				parentSelfSenders: selfSenders 
				providedInParent: provided 
				noInheritedSelfSenders: (provided not and: [selfSenders isEmpty])]].