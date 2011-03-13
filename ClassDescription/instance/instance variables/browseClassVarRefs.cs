browseClassVarRefs 
	"1/17/96 sw: moved here from Browser so that it could be used from a variety of places."

	| lines labelStream vars allVars index owningClasses |

	lines _ OrderedCollection new.
	allVars _ OrderedCollection new.
	owningClasses _ OrderedCollection new.
	labelStream _ WriteStream on: (String new: 200).
	self withAllSuperclasses reverseDo:
		[:class |
		vars _ class classVarNames asSortedCollection.
		vars do:
			[:var |
			labelStream nextPutAll: var; cr.
			allVars add: var.
			owningClasses add: class].
		vars isEmpty ifFalse: [lines add: allVars size]].
	labelStream skip: -1 "cut last CR".
	index _ (PopUpMenu labels: labelStream contents lines: lines) startUp.
	index = 0 ifTrue: [^ self].
	Smalltalk browseAllCallsOn:
		((owningClasses at: index) classPool associationAt: (allVars at: index))