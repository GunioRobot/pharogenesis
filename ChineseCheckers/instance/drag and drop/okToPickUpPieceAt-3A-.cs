okToPickUpPieceAt: boardLoc

	^ (self at: boardLoc) = whoseMove and: [(autoPlay at: whoseMove) not]