canCastleWhiteKingSide
	(castlingStatus bitAnd: CastlingEnableKingSide) = 0 ifFalse: [^false].
	"Quickly check if all the squares are zero"
	((myPieces at:G1) + (myPieces at:F1) + (itsPieces at:G1) + (itsPieces at:F1) = 0) ifFalse:[^false].
	"Check for castling squares under attack..  See canCastleBlackQueenSide for details"
	(self checkAttack:{H2. H3. H4. H5. H6. H7. H8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{G2. G3. G4. G5. G6. G7. G8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{F2. F3. F4. F5. F6. F7. F8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{E2. E3. E4. E5. E6. E7. E8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{A1. A2. A3. A4} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{G2. F3. E4. D5. C6. B7. A8} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F2. E3. D4. C5. B6. A7} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{E2. D3. C4. B5. A6} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D2. C3. B4. A5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F2. G3. H4} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{G2. H3} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{H2} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkUnprotectedAttack:{H2. G2. F2. E2. D2. C2. H3. G3. F3. E3. D3} fromPiece:Knight) ifTrue:[^false].
	(self checkUnprotectedAttack:{H2. G2. F2. E2. D2} fromPiece:Pawn) ifTrue:[^false].
	(self checkUnprotectedAttack:{G2} fromPiece:King) ifTrue:[^false].
	^true.