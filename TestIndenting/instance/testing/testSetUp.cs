testSetUp
	"just reminding us all what the paragraph looks like to begin with. assuming Accuny12 font "
	| cb |

	
	cb := para characterBlockForIndex: 1.  "p"
	self assert: cb top = 0.
	self assert: cb left = 0.
	self assert: cb right = 7.
	
	
	cb := para characterBlockForIndex: 2.  "the tab"
	self assert: cb top = 0.
	self assert: cb left = 7.
	self assert: cb right = 24.

	
	cb := para characterBlockForIndex: 3.  "w" 
	self assert: cb top = 0.
	self assert: cb left = 24.
	self assert: cb right = 34.
	
	cb := para characterBlockForIndex: 7.  " " "between word and word"
	self assert: cb top = 0.
	self assert: cb left = 52.
	self assert: cb right = 57.
	
	cb := para characterBlockForIndex: 11.  "d" "last char"
	self assert: cb top = 0.
	self assert: cb left = 79.
	self assert: cb right = 85.
	
		
