decorateForInheritance
	"Check to see if the currently-viewed method has a super send or an override, and if so, change screen feedback, unless the #decorateBrowserButtons says not to."

	| aColor aButton flags |
	(aButton _ self inheritanceButton) ifNil: [^ self].

	((currentCompiledMethod isKindOf: CompiledMethod) and: [Preferences decorateBrowserButtons])
		ifFalse: [^aButton offColor: Color transparent].

	"This table duplicates the old logic, but adds two new colors for the cases where there is a superclass definition, but this method doesn't call it."

	flags _ 0.
	self isThisAnOverride ifTrue: [ flags _ flags bitOr: 4 ].
	currentCompiledMethod sendsToSuper ifTrue: [ flags _ flags bitOr: 2 ].
	self isThereAnOverride ifTrue: [ flags _ flags bitOr: 1 ].
	aColor _ {
		Color transparent.
		Color tan lighter.
		Color green muchLighter.
		Color blue muchLighter.
		Color red muchLighter.	"has super but doesn't call it"
		(Color r: 0.94 g: 0.823 b: 0.673).	"has sub; has super but doesn't call it"
		Color green muchLighter.
		Color blue muchLighter.
	} at: flags + 1.

	aButton offColor: aColor