nonEmpty1Element
" return a collection of size 1 including one element"
	^ OrderedCollection new add:( self nonEmpty anyOne); yourself.