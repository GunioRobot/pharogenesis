initializeTextEditorMenus
	"Initialize the yellow button pop-up menu and corresponding messages."
	"ParagraphEditor initializeTextEditorMenus"

	TextEditorYellowButtonMenu _ SelectionMenu
		fromArray: {
		{'find...(f)' translated.		#find}.			     
		{'find again (g)' translated.		#findAgain}.		     
		{'set search string (h)' translated.	#setSearchString}.
		#-.	     
		{'do again (j)' translated.		#again}.		     
		{'undo (z)' translated.			#undo}.			     
		#-.	     
		{'copy (c)' translated.			#copySelection}.	     
		{'cut (x)' translated.			#cut}.			     
		{'paste (v)' translated.		#paste}.		     
		{'paste...' translated.			#pasteRecent}.		     
		#-.	     
		{'do it (d)' translated.		#doIt}.			     
		{'print it (p)' translated.		#printIt}.		     
		{'inspect it (i)' translated.		#inspectIt}.		     
		{'explore it (I)' translated.		#exploreIt}.		     
		{'debug it' translated.			#debugIt}.		     
		#-.	     
		{'accept (s)' translated.		#accept}.		     
		{'cancel (l)' translated.		#cancel}.		     
		#-.	     
		{'show bytecodes' translated.		#showBytecodes}.	     
		#-.	     
		{'more...' translated.			#shiftedTextPaneMenuRequest}.
	}
