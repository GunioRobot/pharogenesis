fieldListMenuForCollection: aMenu

	^ aMenu labels: 'inspect (i)
inspect element...
explore (I)
method refs to this inst var
methods storing into this inst var
objects pointing to this value
copy name
browse full (b)
browse class
browse hierarchy
inst var refs...
inst var defs...
class var refs...
class variables
class refs
basic inspect'
	lines: #(3 6 7 10 12 15)
	selections: #(inspectSelection inspectElement exploreSelection referencesToSelection defsOfSelection objectReferencesToSelection copyName  browseMethodFull browseClass classHierarchy browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs inspectBasic).
