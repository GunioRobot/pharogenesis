makeBookStyle: nColumns

	| all totalWidth second columnWidth currY prev columnHeight currX currColumn pageBreakRectangles r rm columnGap pageGap starter |

	pageBreakRectangles _ OrderedCollection new.
	all _ thePasteUp allTextPlusMorphs.
	all size = 1 ifFalse: [^self].
	Cursor wait show.
	starter _ prev _ all first.
	totalWidth _ self width - 16.
	columnGap _ 32.
	pageGap _ 16.
	columnWidth _ totalWidth - (columnGap * (nColumns - 1)) // nColumns.
	columnHeight _ self height - 12.
	currY _ 4.
	currX _ 4.
	currColumn _ 1.
	prev
		position: currX@currY;
		width: columnWidth.
	[
		second _ prev makeSuccessorMorph.
		thePasteUp addMorphBack: second.
		prev 
			setProperty: #autoFitContents toValue: false;
			height: columnHeight.
		(currColumn _ currColumn + 1) <= nColumns ifTrue: [
			currX _ currX + columnWidth + columnGap.
		] ifFalse: [
			r _ 4@(prev bottom + 4) corner: (self right - 4 @ (prev bottom + pageGap - 4)).
			rm _ RectangleMorph new bounds: r; color: (Color gray alpha: 0.3); borderWidth: 0.
			pageBreakRectangles add: rm beSticky.
			thePasteUp addMorphBack: rm.
			currColumn _ 1.
			currX _ 4.
			currY _ prev bottom + pageGap.
		].
		second 
			autoFit: true;
			position: currX@currY;
			width: columnWidth.
		prev recomposeChain.		"was commented"
		prev _ second.
		prev height > columnHeight
	] whileTrue.
	prev autoFit: true.
	thePasteUp height: (prev bottom + 20 - self top).
	self layoutChanged.
	self setProperty: #pageBreakRectangles toValue: pageBreakRectangles.
	thePasteUp allTextPlusMorphs do: [ :each |
		each repositionAnchoredMorphs
	].
	Cursor normal show.
