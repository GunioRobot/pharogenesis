removeStayUpItems
	| stayUpItems |
	stayUpItems _ self items select: [ :item | item isStayUpItem ].
	stayUpItems do: [ :ea | ea delete ].
