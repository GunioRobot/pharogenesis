addButtons
	| r b w |

	caption ifNotNil:
		["Special setup for play-only interface"
		r _ AlignmentMorph newRow vResizing: #shrinkWrap;
			 wrapCentering: #center; cellPositioning: #leftCenter;
			 minCellSize: 4;
			 color: Color blue.
		r addMorphBack: (SimpleButtonMorph new target: self;
	 							label: caption; actionSelector: #play).
		r addMorphBack: (Morph new extent: 4@4; color: Color transparent).
		r addMorphBack: (statusLight _ EllipseMorph new extent: 11 @ 11;
								color: Color green; borderWidth: 0).
		r addMorphBack: (Morph new extent: 4@4; color: Color transparent).
		^ self addMorphBack: r].

	"record - stop - play"
	r _ AlignmentMorph newRow vResizing: #shrinkWrap;
			 minCellSize: 4;
			 color: Color blue.
	r addMorphBack: (b _ self buttonFor: #record).
	w _ b width.
	r addMorphBack: (AlignmentMorph newSpacer: Color transparent).
	r addMorphBack: ((self buttonFor: #stop) width: w).
	r addMorphBack: (AlignmentMorph newSpacer: Color transparent).
	r addMorphBack: ((self buttonFor: #play) width: w).
	self addMorphBack: r.

	"read file - write file"
	r _ AlignmentMorph newRow vResizing: #shrinkWrap;
			 minCellSize: 4;
			 color: Color blue.
	r addMorphBack: (b _ self buttonFor: #writeTape).
	w _ b width.
	r addMorphBack: (AlignmentMorph newSpacer: Color transparent).
	r addMorphBack: ((self buttonFor: #readTape)
			width: w).
	self addMorphBack: r.

	"rewind - light - reset"
	r _ AlignmentMorph newRow vResizing: #shrinkWrap;
			 wrapCentering: #center; cellPositioning: #leftCenter;
			 minCellSize: 4;
			 color: Color blue.
	r addMorphBack: (b _ self buttonFor: #shrink).
	w _ b width.
	r addMorphBack: (AlignmentMorph newSpacer: Color transparent).
	r addMorphBack: (statusLight _ EllipseMorph new extent: 11 @ 11;
			color: Color green;
		 	borderWidth: 0).
	r addMorphBack: (AlignmentMorph newSpacer: Color transparent).
	r addMorphBack: ((self buttonFor: #button)
			width: w).
	self addMorph: r