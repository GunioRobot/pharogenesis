polygonMode
	"Return the current polygon mode (either #points, #lines or nil)"
	| value |
	value _ self primRender: handle getProperty: 2.
	value = 1 ifTrue:[^#lines].
	value = 2 ifTrue:[^#points].
	^nil