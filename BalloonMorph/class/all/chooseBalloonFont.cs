chooseBalloonFont
	| sizes reply |
	sizes _ #(9 10 12 14).
	reply _ (SelectionMenu labelList: (sizes collect: [:s | s printString]) selections:  sizes) startUp.
	reply ifNotNil:
		[BalloonFont _ (TextStyle named: #ComicPlain) fontAt: (sizes indexOf: reply)]