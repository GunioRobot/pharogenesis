classMenu: aMenu
	"Could be for a single or double changeSorter"
	parent ifNotNil: [
		^ aMenu labels: 
'copy to other side
delete from this change set
browse full
inst var refs...
inst var defs...
class var refs...
class vars'
		lines: #(2 3 )
		selections: #(copyClassToOther forgetClass browseMethodFull browseInstVarRefs browseInstVarDefs browseClassVarRefs browseClassVariables)]

	ifNil: [
		^ aMenu labels: 
'delete from this change set
browse full
inst var refs...
inst var defs...
class var refs...
class vars'
		lines: #(1 2 )
		selections: #(forgetClass browseMethodFull browseInstVarRefs browseInstVarDefs browseClassVarRefs browseClassVariables)]