showScoreDisplay

	^self rowForButtons
		hResizing: #rigid;
		addMorph: (
			self 
				wrapPanel: (
					(scoreDisplay _ LedMorph new) digits: 5; extent: (4*10@15)
				) 
				label: 'Score:'
		)
