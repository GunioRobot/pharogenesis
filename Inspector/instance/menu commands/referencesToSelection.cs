referencesToSelection
	"Open a browser on all references to the selected instance variable, if that's what currently selected.  1/25/96 sw"
	| aClass sel |

	self selectionUnmodifiable ifTrue: [^ self changed: #flash].
	(aClass _ self object class) isVariable ifTrue: [^ self changed: #flash].

	sel _ aClass allInstVarNames at: self selectionIndex - 2.
	self systemNavigation   browseAllAccessesTo: sel from: aClass