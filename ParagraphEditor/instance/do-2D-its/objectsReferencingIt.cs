objectsReferencingIt
	"Open a list inspector on all objects that reference the object that results when the current selection is evaluated.  "
	| result |
	self terminateAndInitializeAround: [
	result _ self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
		ifTrue: [view flash]
		ifFalse: [self systemNavigation
					browseAllObjectReferencesTo: result
					except: #()
					ifNone: [:obj | view topView flash]].
	]