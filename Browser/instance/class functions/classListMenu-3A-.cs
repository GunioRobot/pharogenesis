classListMenu: aMenu

^ aMenu labels: 
'browse class
browse full
printOut
fileOut
hierarchy
definition
comment
spawn hierarchy
spawn protocol
inst var refs..
inst var defs..
class var refs...
class vars
class refs
rename...
remove
unsent methods
find method...' 
	lines: #(4 7 9 11 14 16)
	selections:
		#(buildClassBrowser browseMethodFull printOutClass fileOutClass
		hierarchy editClass editComment
		spawnHierarchy spawnProtocol
		browseInstVarRefs browseInstVarDefs browseClassVarRefs 
		browseClassVariables browseClassRefs
		renameClass removeClass browseUnusedMethods findMethod)
