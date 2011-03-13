objectsReferencingIt
	"Open a list inspector on all objects that reference the object that results when the current selection is evaluated.  "
	| result |
	self controlTerminate.
	result _ self evaluateSelection.
	((result isKindOf: FakeClassPool) or: [result == #failedDoit])
		ifTrue: [view flash]
		ifFalse: [Smalltalk
					browseAllObjectReferencesTo: result
					except: #()
					ifNone: [:obj | view topView flash]].
	self controlInitialize