recent
	| response sortedPages currentDate |
	sortedPages _ pages reject: [:page | page pageStatus = #new].
	sortedPages _ sortedPages asSortedCollection: [:a :b | (a date = b
date) ifTrue: [a time > b time]
			ifFalse: [a date > b date]].
	response _ WriteStream on: String new.
	response nextPutAll: '<h2>Recent Changes</h2><ul>'.
	currentDate _ Date new.
	sortedPages do: [:page |
		(currentDate ~= page date)
		ifTrue: [
			currentDate _ page date.
			response nextPutAll: '</ul><p><b>',(currentDate
printString),'</b><p><ul>'.].
		response nextPutAll: '<li>',(self pageURL:
page),'...',(page address).
		(page privs includesSubString: 'read') ifTrue:
			[response nextPutAll: '  <b>Read protected</b>'.].
		(page privs includesSubString: 'write') ifTrue:
			[response nextPutAll: '  <b>Write protected</b>'.].].
	response nextPutAll: '</ul>'.
	^response contents
