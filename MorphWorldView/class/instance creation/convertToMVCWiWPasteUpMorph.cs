convertToMVCWiWPasteUpMorph
	"
MorphWorldView convertToMVCWiWPasteUpMorph
"

	| current w newModel topView |
	Smalltalk isMorphic ifTrue: [^self inform: 'do this in MVC'].
	current := self allInstances 
				select: [:each | each model class == PasteUpMorph].
	current do: 
			[:oldWorldView | 
			w := MVCWiWPasteUpMorph newWorldForProject: nil.
			w
				color: oldWorldView model color;
				addAllMorphs: oldWorldView model submorphs.
			newModel := CautiousModel new initialExtent: 300 @ 300.
			topView := self fullColorWhenInactive 
						ifTrue: [ColorSystemView new]
						ifFalse: [StandardSystemView new].
			topView
				model: newModel;
				label: oldWorldView topView label;
				borderWidth: 1;
				addSubView: (self new model: w);
				backgroundColor: w color.
			topView controller openNoTerminate.
			topView reframeTo: (oldWorldView topView expandedFrame 
						expandBy: (0 @ 0 extent: 0 @ topView labelHeight)).
			oldWorldView topView controller closeAndUnscheduleNoTerminate].
	ScheduledControllers restore.
	Processor terminateActive