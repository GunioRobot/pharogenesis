canCastleBlackQueenSide
	(castlingStatus bitAnd: CastlingEnableQueenSide) = 0 ifFalse:[^false].
	"Quickly check if all the squares are zero"
	((myPieces at: B8) +  (myPieces at: C8) +  (myPieces at: D8) +
		(itsPieces at: B8) + (itsPieces at: C8) + (itsPieces at: D8) 
			= 0) ifFalse:[^false].
	"Check to see if any of the squares involved in castling are under attack.  First
	check for vertical (rook-like) attacks"
	(self checkAttack:{A7. A6. A5. A4. A3. A2. A1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{B7. B6. B5. B4. B3. B2. B1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{C7. C6. C5. C4. C3. C2. C1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{D7. D6. D5. D4. D3. D2. D1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{E7. E6. E5. E4. E3. E2. E1} fromPieces:RookMovers) ifTrue:[^false].
	"Check for a rook attack from the baseline"
	(self checkAttack:{F8. G8. H8} fromPieces:RookMovers) ifTrue:[^false].
	"Check for bishop attacks from the diagonals"
	(self checkAttack:{B7. C6. D5. E4. F3. G2. H1} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{C7. D6. E5. F4. G3. H2} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D7. E6. F5. G4. H3} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{E7. F6. G5. H4} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F7. G6. H5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{A7} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{B7. A6} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{C7. B6. A5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D7. C6. B5. A4} fromPieces:BishopMovers) ifTrue:[^false].
	"Check for a knight attack"
	(self checkUnprotectedAttack:{A7. B7. C7. D7. E7. F7. G7. A6. B6. C6. D6. E6. F6} fromPiece:Knight) ifTrue:[^false].
	"check for a pawn attack"
	(self checkUnprotectedAttack:{A7. B7. C7. D7. E7. F7} fromPiece:Pawn) ifTrue:[^false].
	"check for a king attack"
	(self checkUnprotectedAttack:{B7. C7. } fromPiece:King) ifTrue:[^false].
	^true.
