objectReferencesToSelection
	"Open a list inspector on all the objects that point to the value of the selected instance variable, if any.  "

	model selectionIndex == 0 ifTrue: [^ view flash].
	self controlTerminate.
	Smalltalk
		browseAllObjectReferencesTo: model selection
		except: (Array with: model object)
		ifNone: [:obj | view topView flash].
