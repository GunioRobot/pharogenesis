restorePrivateGraphics
	"ScriptingSystem restorePrivateGraphics"
	| aReferenceStream |
	aReferenceStream _ ReferenceStream fileNamed: 'disGraphics'.
	self mergeGraphicsFrom: aReferenceStream next.
	aReferenceStream close.
