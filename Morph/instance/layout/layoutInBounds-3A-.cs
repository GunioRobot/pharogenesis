layoutInBounds: cellBounds
	"Layout specific. Apply the given bounds to the receiver after being layed out in its owner."
	| box aSymbol delta |
	fullBounds ifNil:["We are getting new bounds here but we haven't computed the receiver's layout yet. Although the receiver has reported its minimal size before the actual size it has may differ from what would be after the layout. Normally, this isn't a real problem, but if we have #shrinkWrap constraints then the receiver's bounds may be larger than the cellBounds. THAT is a problem because the centering may not work correctly if the receiver shrinks after the owner layout has been computed. To avoid this problem, we compute the receiver's layout now. Note that the layout computation is based on the new cell bounds rather than the receiver's current bounds."
		cellBounds origin = self bounds origin ifFalse:[
			box _ self outerBounds.
			delta _ cellBounds origin - self bounds origin.
			self invalidRect: (box merge: (box translateBy: delta)).
			self privateFullMoveBy: delta]. "sigh..."
		box _ cellBounds origin extent: "adjust for #rigid receiver"
			(self hResizing == #rigid ifTrue:[self bounds extent x] ifFalse:[cellBounds extent x]) @
			(self vResizing == #rigid ifTrue:[self bounds extent y] ifFalse:[cellBounds extent y]).
		"Compute inset of layout bounds"
		box _ box origin - (self bounds origin - self layoutBounds origin) corner:
					box corner - (self bounds corner - self layoutBounds corner).
		"And do the layout within the new bounds"
		self layoutBounds: box.
		self doLayoutIn: box].
	cellBounds = self fullBounds ifTrue:[^self]. "already up to date"
	cellBounds extent = self fullBounds extent "nice fit"
		ifTrue:[^self position: cellBounds origin].
	box _ bounds.
	"match #spaceFill constraints"
	self hResizing == #spaceFill 
		ifTrue:[box _ box origin extent: cellBounds width @ box height].
	self vResizing == #spaceFill
		ifTrue:[box _ box origin extent: box width @ cellBounds height].
	"align accordingly"
	aSymbol _ (owner ifNil:[self]) cellPositioning.
	box _ box align: (box perform: aSymbol) with: (cellBounds perform: aSymbol).
	"and install new bounds"
	self bounds: box.