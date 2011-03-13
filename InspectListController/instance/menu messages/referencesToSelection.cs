referencesToSelection
	"Open a browser on all references to the selected instance variable, if that's what currently selected.  1/25/96 sw"

	| aClass sel |

	model selectionUnmodifiable ifTrue: [^ view flash].
	(aClass _ model object class) isVariable ifTrue: [^ view flash].
	self controlTerminate.

	sel _ aClass allInstVarNames at: model selectionIndex - 2.
	aClass browseAllAccessesTo: sel