setLocalInstVarDefs
	"Put up a list of the instance variables in the viewed object, and when the user seletcts one, let the query results category show all the references to that instance variable."

	| instVarToProbe |

	targetClass chooseInstVarThenDo:
		[:aName | instVarToProbe _ aName].
	instVarToProbe isEmptyOrNil ifTrue: [^ self].
	currentQuery _ #instVarDefs.
	currentQueryParameter _ instVarToProbe.
	self showQueryResultsCategory