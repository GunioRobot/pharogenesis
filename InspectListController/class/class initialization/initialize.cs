initialize
	"Initialize the menu associated with the upper-left pane of an Inspector"

	InspectListYellowButtonMenu _ PopUpMenu labels: 'inspect
method refs to this inst var
objects pointing to this value
copy name
browse full
browse class
inst var refs...
inst var defs...
class var refs...
class variables
class refs'
	lines: #(1 3 4     6 8 10 11 ).
	InspectListYellowButtonMessages _ 
		#(inspectSelection referencesToSelection objectReferencesToSelection copyName  browseFull browseClass  browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs unshiftedYellowButtonActivity).

	"InspectListController initialize"