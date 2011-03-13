listMenu: aMenu 
	^ aMenu
		labels: 'add
remove
inspect me
inspect list
inspect list morph'
		lines: #(2 )
		selections: #(#addToTestList #removeFromTestList #inspectMe #inspectList inspectListMorph)