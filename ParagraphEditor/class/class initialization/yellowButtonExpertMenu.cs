yellowButtonExpertMenu
	^ MenuMorph fromArray: {
			{'do it (d)' translated.					#doIt}.
			{'print it (p)' translated.					#printIt}.
			{'inspect it (i)' translated.				#inspectIt}.
			{'explore it (I)' translated.				#exploreIt}.
			{'debug it (D)' translated.				#debugIt}.
			{'profile it' translated.						#tallyIt}.
		     {'watch it' translated.					#watchIt}.	 
		    	 
			#-.
			{'find...(f)' translated.					#find}.
			{'find again (g)' translated.				#findAgain}.
			{'extended search...' translated.			#shiftedTextPaneMenuRequest}.
			#-.
			{'do again (j)' translated.				#again}.
			{'undo (z)' translated.					#undo}.
			#-.
			{'copy (c)' translated.					#copySelection}.
			{'cut (x)' translated.						#cut}.
			{'paste (v)' translated.					#paste}.
			{'paste...' translated.					#pasteRecent}.
			#-.
			{'accept (s)' translated.					#accept}.
			{'cancel (l)' translated.					#cancel}.
		}.
