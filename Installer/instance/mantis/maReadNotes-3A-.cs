maReadNotes: page 

	 |  notes note  |
 
	notes := OrderedCollection new.

	[ page upToAll: 'tr class="bugnote"'; upTo: $>.
	  page atEnd ]
		
	whileFalse: [ 
		note := (self removeHtmlMarkupFrom: (page upToAll: '</tr>') readStream) contents.
		note := note withBlanksCondensed.
		"note replaceAll: Character cr with: $ ."
		note replaceAll: Character lf with: Character cr.
		notes add: note  
	].
	
	^notes