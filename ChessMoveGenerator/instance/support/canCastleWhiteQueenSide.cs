canCastleWhiteQueenSide
	(castlingStatus bitAnd: CastlingEnableQueenSide) = 0 ifFalse: [^false].
	"Quickly check if all the squares are zero"
	((myPieces at:B1) + (myPieces at:C1) + (myPieces at:D1) +
	 (itsPieces at:B1) + (itsPieces at:C1) + (itsPieces at:D1) = 0) ifFalse:[^false].
	"Check for castling squares under attack..  See canCastleBlackQueenSide for details"
	(self checkAttack:{A2. A3. A4. A5. A6. A7. A8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{B2. B3. B4. B5. B6. B7. B8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{C2. C3. C4. C5. C6. C7. C8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{D2. D3. D4. D5. D6. D7. D8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{E2. E3. E4. E5. E6. E7. E8} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{F1. G1. H1} fromPieces:RookMovers) ifTrue:[^false].
	(self checkAttack:{B2. C3. D4. E5. F6. G7. H8} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{C2. D3. E4. F5. G6. H7} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D2. E3. F4. G5. H6} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{E2. F3. G4. H5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{F2. G3. H4} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{A2} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{B2. A3} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{C2. B3. A4} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkAttack:{D2. C3. B4. A5} fromPieces:BishopMovers) ifTrue:[^false].
	(self checkUnprotectedAttack:{A2. B2. C2. D2. E2. F2. G2. A3. B3. C3. D3. E3. F3} fromPiece:Knight) ifTrue:[^false].
	(self checkUnprotectedAttack:{A2. B2. C2. D2. E2. F2} fromPiece:Pawn) ifTrue:[^false].
	(self checkUnprotectedAttack:{B2. C2} fromPiece:King) ifTrue:[^false].
	^true.