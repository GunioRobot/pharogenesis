menuGet: aMenu shifted: shifted
	
	aMenu addList: {
		{'find...(f)' translated.		#find}.
		{'find again (g)' translated.		#findAgain}.
		{'set search string (h)' translated.	#setSearchString}.
			#-.
		{'accept (s)' translated. #accept}.
		{'send message' translated.  #submit}}.

	^aMenu.