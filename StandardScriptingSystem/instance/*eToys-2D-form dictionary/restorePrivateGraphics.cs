restorePrivateGraphics
	"ScriptingSystem restorePrivateGraphics"
	| aReferenceStream |
	aReferenceStream := ReferenceStream fileNamed: 'disGraphics'.
	self mergeGraphicsFrom: aReferenceStream next.
	aReferenceStream close.
