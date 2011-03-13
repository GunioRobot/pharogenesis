objectsReferencingIt
	"Open a list inspector on all objects that reference the object that results when the current selection is evaluated.  "
	| result |
	self terminateAndInitializeAround: [
	result := self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
		ifTrue: [self flash]
		ifFalse: [self systemNavigation
					browseAllObjectReferencesTo: result
					except: #()
					ifNone: [:obj | self flash]].
	]