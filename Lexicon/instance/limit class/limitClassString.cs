limitClassString
	"Answer a string representing the current choice of most-generic-class-to-show"

	| most |
	(most _ self limitClass) == ProtoObject
		ifTrue:	[^ 'All'].
	most == targetClass
		ifTrue:	[^ most name].
	^ 'Only through ', most name