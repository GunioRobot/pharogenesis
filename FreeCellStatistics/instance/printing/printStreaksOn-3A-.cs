printStreaksOn: aStream 
	aStream nextPutAll: 'Streaks: ' translated;
		 tab;
		 tab.
	self
		print: streakWins
		type: #wins
		on: aStream.
	aStream nextPutAll: ', '.
	self
		print: streakLosses
		type: #losses
		on: aStream.
	aStream cr; tab; tab; tab; tab; nextPutAll: 'Current: '.
	self
		print: currentCount
		type: currentType
		on: aStream