checkForFullRows

	| targetY morphsInRow bonus |
	self numRows to: 2 by: -1 do: [ :row |
		targetY _ (self originForCell: 1@row) y.
		[
			morphsInRow _ self submorphsSatisfying: [ :each | each top = targetY].
			morphsInRow size = self numColumns
		] whileTrue: [
			bonus _ (morphsInRow collect: [:each | each color]) asSet size = 1 
				ifTrue: [1000] 
				ifFalse: [100].
			self score: score + bonus.
			submorphs copy do: [ :each |
				each top = targetY ifTrue: [
					each delete
				].
				each top < targetY ifTrue: [
					each position: each position + (0@self cellSize y)
				].
			].
		].
	].

