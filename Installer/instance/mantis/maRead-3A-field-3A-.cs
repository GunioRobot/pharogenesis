maRead: page field: fieldKey

	 | value |
 
	value := page upToAll: ('!-- ', fieldKey, ' -->'); upToAll: '<td'; upTo: $>; upToAll: '</td>'.
	
	page upTo: $<.
	
	page peek = $t ifTrue: [ value := page upToAll: 'td'; upTo: $>; upToAll: '</td>' ].
	  
	^Association key: fieldKey value: value withBlanksTrimmed