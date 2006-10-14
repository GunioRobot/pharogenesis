initialize
	"Initialize a system window. Add label, stripes, etc., if desired"
	super initialize.
	allowReframeHandles _ true.
	labelString ifNil: [labelString _ 'Untitled Window'].
	isCollapsed _ false.
	activeOnlyOnTop _ true.
	paneMorphs _ Array new.
	borderColor _ Color lightGray.
	borderWidth _ 1.
	self color: Color lightGray lighter lighter lighter.
	self layoutPolicy: ProportionalLayout new.
	
	self initializeLabelArea.
				
	self addCornerGrips.

	self extent: 300 @ 200.
	mustNotClose _ false.
	updatablePanes _ Array new.
		
	Preferences menuAppearance3d
		ifTrue: [
			self
				addDropShadow;
				shadowColor: (TranslucentColor r: 0.0 g: 0.0 b: 0.0 alpha: 0.333);
				shadowOffset: 1@1.
		].
					