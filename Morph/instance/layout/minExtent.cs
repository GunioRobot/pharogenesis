minExtent
	"Layout specific. Return the minimum size the receiver can be represented in.
	Implementation note: When this message is sent from an owner trying to lay out its children it will traverse down the morph tree and recompute the minimal arrangement of the morphs based on which the minimal extent is returned. When a morph with some layout strategy is encountered, the morph will ask its strategy to compute the new arrangement. However, since the final size given to the receiver is unknown at the point of the query, the assumption is made that the current bounds of the receiver are the base on which the layout should be computed. This scheme prevents strange layout changes when for instance, a table is contained in another table. Unless the inner table has been resized manually (which means its bounds are already enlarged) the arrangement of the inner table will not change here. Thus the entire layout computation is basically an iterative process which may have different results depending on the incremental changes applied."
	| layout minExtent extra hFit vFit |
	hFit _ self hResizing.
	vFit _ self vResizing.
	(hFit == #spaceFill or:[vFit == #spaceFill]) ifFalse:[
		"The receiver will not adjust to parents layout by growing or shrinking,
		which means that an accurate layout defines the minimum size."
		^self fullBounds extent].

	"An exception -- a receiver with #shrinkWrap constraints but no children is being treated #rigid (the equivalent to a #spaceFill receiver in a non-layouting owner)"
	self hasSubmorphs ifFalse:[
		hFit == #shrinkWrap ifTrue:[hFit _ #rigid].
		vFit == #shrinkWrap ifTrue:[vFit _ #rigid]].
	layout _ self layoutPolicy.
	layout == nil
		ifTrue:[minExtent _ 0@0]
		ifFalse:[minExtent _ layout minExtentOf: self in: self layoutBounds].
	hFit == #rigid
		ifTrue:[	minExtent _ self fullBounds extent x @ minExtent y]
		ifFalse:[	extra _ self bounds width - self layoutBounds width.
				minExtent _ (minExtent x + extra) @ minExtent y].
	vFit == #rigid
		ifTrue:[minExtent _ minExtent x @ self fullBounds extent y]
		ifFalse:[extra _ self bounds height - self layoutBounds height.
				minExtent _ minExtent x @ (minExtent y + extra)].
	minExtent _ minExtent max: (self minWidth@self minHeight).
	^minExtent