keyboardNavigationHandler
	"Answer the receiver's existing keyboardNavigationHandler, or nil if none."

	| aHandler |
	aHandler _ self valueOfProperty: #keyboardNavigationHandler ifAbsent: [^ nil].
	(aHandler hasProperty: #moribund) ifTrue:  "got clobbered in another project"
		[self removeProperty: #keyboardNavigationHander.
		^ nil].
	^ aHandler