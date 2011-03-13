fieldListMenu: aMenu

	^ aMenu labels: 'inspect
method refs to this inst var
objects pointing to this value
copy name
browse full
browse class
inst var refs...
inst var defs...
class var refs...
class variables
class refs
basic inspect'
	lines: #(1 3 4  6 8 11 )
	selections: #(inspectSelection referencesToSelection objectReferencesToSelection copyName  browseMethodFull browseClass browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs inspectBasic).
