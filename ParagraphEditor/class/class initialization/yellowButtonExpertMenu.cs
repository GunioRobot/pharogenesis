yellowButtonExpertMenu

	^ MenuMorph fromArray: {
			{'set font... (k)' translated.				#offerFontMenu}.
			{'set style... (K)' translated.				#changeStyle}.
			{'set alignment... (u)' translated.		#chooseAlignment}.
			#-.
			{'make project link (P)' translated.	#makeProjectLink}.
			#-.
			{'find...(f)' translated.					#find}.
			{'find again (g)' translated.				#findAgain}.
			{'set search string (h)' translated.		#setSearchString}.
			#-.
			{'do again (j)' translated.				#again}.
			{'undo (z)' translated.					#undo}.
			#-.
			{'copy (c)' translated.					#copySelection}.
			{'cut (x)' translated.						#cut}.
			{'paste (v)' translated.					#paste}.
			{'paste...' translated.					#pasteRecent}.
			#-.
			{'do it (d)' translated.					#doIt}.
			{'print it (p)' translated.				#printIt}.
			{'inspect it (i)' translated.				#inspectIt}.
			{'explore it (I)' translated.				#exploreIt}.
			{'debug it' translated.					#debugIt}.
			#-.
			{'accept (s)' translated.					#accept}.
			{'cancel (l)' translated.					#cancel}.
			#-.
			{'show bytecodes' translated.			#showBytecodes}.
			#-.
			{'copy html' translated.					#copyHtml}.
			#-.
			{'more...' translated.					#shiftedTextPaneMenuRequest}.
		}.
