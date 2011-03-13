initialize
	"Initialize the yellow button menu information.
	 2/1/96 sw: added class vars
	 7/29/96 sw: added 'find method' feature"
	
	ClassListYellowButtonMenu _
		PopUpMenu 
				labels: 
'browse class
printOut
fileOut
hierarchy
definition
comment
inst var refs..
class var refs...
class vars
class refs
rename...
remove
find method...' 
				lines: #(3 6 10 12).
	ClassListYellowButtonMessages _ 
		#(browse printOut fileOut
		hierarchy definition comment
		browseInstVarRefs browseClassVarRefs classVariables browseClassRefs
		rename remove findMethod)
	"
	ClassListController initialize.
	ClassListController allInstancesDo:
		[:x | x initializeYellowButtonMenu].
	"