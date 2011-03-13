initialize
	"Initialize the receiver."

	super initialize.
	listSelectionIndex := 0.
	enabled := true.
	list := #().
	self
		useSelectionIndex: true;
		clipSubmorphs: true;
		layoutPolicy: RowLayout new;
		layoutInset: (self theme dropListInsetFor: self);
		cellPositioning: #center;
		listMorph: self newListMorph;
		contentMorph: self newContentMorph;
		buttonMorph: self newButtonMorph;
		borderStyle: self borderStyleToUse;
		addMorphBack: self contentMorph;
		addMorphBack: (self addDependent: self buttonMorph);
		on: #mouseDown send: #popList to: self.
	self listMorph fillStyle: (self theme dropListNormalListFillStyleFor: self)