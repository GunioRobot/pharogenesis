setLocalClassVarRefs
	"Put up a list of the class variables in the viewed object, and when the user selects one, let the query results category show all the references to that class variable."

	| aName |

	(aName := targetClass theNonMetaClass chooseClassVarName) ifNil: [^ self].
	currentQuery := #classVarRefs.
	currentQueryParameter := aName.
	self showQueryResultsCategory