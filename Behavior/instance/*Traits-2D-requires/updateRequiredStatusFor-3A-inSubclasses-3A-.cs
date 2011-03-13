updateRequiredStatusFor: selector inSubclasses: someClasses
	"Updates the requirements cache to reflect whether selector is required in this class and some of its subclasses."
	| inheritedMethod |
	inheritedMethod := self superclass ifNotNil: [self superclass lookupSelector: selector].
	^self updateRequiredStatusFor: selector  inSubclasses: someClasses parentSelfSenders: FixedIdentitySet new providedInParent: inheritedMethod noInheritedSelfSenders: false accumulatingInto: IdentitySet new.