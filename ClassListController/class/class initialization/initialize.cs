initialize
        "Initialize the yellow button menu information.
         2/1/96 sw: added class vars
         7/29/96 sw: added 'find method' feature
        11/11/96 stp: added spawn protocol and separated show/spawn hierarchy
        : added recent classes feature
	   : recent classes feature moved to system category-list pane"
        
        ClassListYellowButtonMenu :=
                PopUpMenu 
                                labels: 
'browse class
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
                                lines: #(3 6 8 10 13 16).
        ClassListYellowButtonMessages := 
                #(browse  printOut fileOut
                hierarchy definition comment
                spawnHierarchy spawnProtocol
                browseInstVarRefs browseInstVarDefs browseClassVarRefs classVariables browseClassRefs
                rename remove browseUnusedMethods findMethod)
        "
        ClassListController initialize.
        ClassListController allInstancesDo:
                [:x | x initializeYellowButtonMenu].
        "