fieldListMenu: aMenu
	| sel |
	((((sel _ self selection) isMemberOf: Array) or: [sel isMemberOf: OrderedCollection])
			and: [sel size >= 1])
		ifTrue:
			[^ self fieldListMenuForCollection: aMenu].

	^ aMenu labels: 'inspect (i)
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
	lines: #(2 5 6 9 11 14)
	selections: #(inspectSelection exploreSelection referencesToSelection defsOfSelection objectReferencesToSelection copyName  browseMethodFull browseClass classHierarchy browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs inspectBasic).
