canCastleBlackKingSide
	(castlingStatus bitAnd: CastlingEnableKingSide) = 0 ifFalse:[^false].
	"Quickly check if all the squares are zero"
	((myPieces at: G8) + (myPieces at: F8) + (itsPieces at: G8) + (itsPieces at: F8) = 0) ifFalse:[^false].
	"Check for castling squares under attack..  See canCastleBlackQueenSide for details"
	(self checkAttack:{H7. H6. H5. H4. H3. H2. H1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{G7. G6. G5. G4. G3. G2. G1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{F7. F6. F5. F4. F3. F2. F1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{E7. E6. E5. E4. E3. E2. E1.} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{D8. C8. B8. A8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{G7. F6. E5. D4. C3. B2. A1} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F7. E6. D5. C4. B3. A2} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{E7. D6. C5. B4. A3} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D7. C6. B5. A4} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F7. G6. H5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{G7. H6} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{H7} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkUnprotectedAttack:{H7. G7. F7. E7. D7. C7. H6. G6. F6. E6. D6} fromPiece:Knight) ifTrue:[^false].
	(self checkUnprotectedAttack:{H7. G7. F7. E7. D7} fromPiece:Pawn) ifTrue:[^false].
	^true.
	
	
	
	
	