setFramesForLabelArea
	"an aid to converting old instances, but then I found  
	convertAlignment (jesse welton's note)"
	| frame |
	labelArea
		ifNil: [^ self].
	frame := LayoutFrame new.
	frame leftFraction: 0.5;
		 topFraction: 0.5;
		 leftOffset: label width negated // 2;
		 topOffset: label height negated // 2.
	label layoutFrame: frame.
	frame := LayoutFrame new.
	frame rightFraction: 1;
		 topFraction: 0;
		 rightOffset: -2;
		 topOffset: 0.
	collapseBox
		ifNotNilDo: [:cb | cb layoutFrame: frame].
	stripes isEmptyOrNil
		ifFalse: [frame := LayoutFrame new.
			frame leftFraction: 0;
				 topFraction: 0;
				 rightFraction: 1;
				 leftOffset: 1;
				 topOffset: 1;
				 rightOffset: -1;
				 bottomOffset: -2.
			stripes first layoutFrame: frame.
			stripes first height: self labelHeight - 1.
			stripes first hResizing: #spaceFill.
			frame := LayoutFrame new.
			frame leftFraction: 0;
				 topFraction: 0;
				 rightFraction: 1;
				 leftOffset: 3;
				 topOffset: 3;
				 rightOffset: -3.
			stripes last layoutFrame: frame.
			stripes last height: self labelHeight - 5.
			stripes last hResizing: #spaceFill].
	labelArea
		ifNotNil: [
			frame := LayoutFrame fractions: (0@0 corner: 1@0) offsets: ((1@self labelHeight negated - 1) corner: 0@0  ).
			Preferences alternativeWindowLook
				ifTrue: [frame leftOffset: 0].
			labelArea layoutFrame: frame]