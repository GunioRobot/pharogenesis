recent
	| response sortedPages currentDate |
	sortedPages _ pages asSortedCollection: [:a :b | a date > b date].
	response _ WriteStream on: String new.
	response nextPutAll: '<h2>Recent Changes</h2><ul>'. 
	currentDate _ Date new.
	sortedPages do: [:page |
		(currentDate ~= page date)
		ifTrue: [
			currentDate _ page date.
			response nextPutAll: '</ul><p><b>',(currentDate printString),'</b><p><ul>'.].
		response nextPutAll: '<li>',(self pageURL: page),'...',(page address).].
	response nextPutAll: '</ul>'. 
	^response contents
		
		