display
	| panel |

	(window notNil and: [window owner notNil]) ifTrue: [window activate. ^nil].
	panel _ AlignmentMorph newColumn.
	panel
		wrapCentering: #center; cellPositioning: #topCenter;
		hResizing: #rigid;
		vResizing: #rigid;
		extent: 250@150;
		color: self color;
		addMorphBack: self makeStatistics;
		addMorphBack: self makeControls.
	window _ panel openInWindowLabeled: 'FreeCell Statistics' translated.