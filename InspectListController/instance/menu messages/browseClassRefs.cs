browseClassRefs
	"Inspect all instances of the selected class and all its subclasses"

	| aClass |
	self controlTerminate.
	(aClass _ self classOfSelection) == nil ifFalse:
		[aClass _ aClass theNonMetaClass.
		 Smalltalk browseAllCallsOn: (Smalltalk associationAt: aClass name)].
	self controlInitialize