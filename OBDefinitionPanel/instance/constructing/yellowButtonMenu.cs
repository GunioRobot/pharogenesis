yellowButtonMenu
	^ {
		{'find...(f)' translated.				#find}.			     
		{'find again (g)' translated.			#findAgain}.		     
		{'set search string (h)' translated.	#setSearchString}.
		#-.	     
		{'do again (j)' translated.			#again}.		     
		{'undo (z)' translated.				#undo}.			     
		#-.	     
		{'copy (c)' translated.				#copySelection}.	     
		{'cut (x)' translated.					#cut}.			     
		{'paste (v)' translated.				#paste}.		     
		{'paste...' translated.					#pasteRecent}.		     
		#-.	     
		{'accept (s)' translated.				#accept}.		     
		{'cancel (l)' translated.				#cancel}.		     
		#-.	     
		{'do it (d)' translated.				#doIt}.			     
		{'print it (p)' translated.				#printIt}.		     
		{'inspect it (i)' translated.			#inspectIt}.		     
		{'explore it (I)' translated.			#exploreIt}.		     
		{'debug it' translated.				#debugIt}.		     
		#-.	     
		{'browse it (b)' translated.					#browseIt}.
		{'senders of it (n)' translated.				#sendersOfIt}.
		{'implementors of it (m)' translated.			#implementorsOfIt}.
		{'references to it (N)' translated.				#referencesToIt}.
		#-.
		{'more...' translated.					#shiftedTextPaneMenuRequest}.
	}
