addButtonRows
	"Spun off to allow subclasses to customize the buttons but still benefit from super intialize"

	| r |
	r _ LayoutMorph newRow vResizing: #shrinkWrap; inset: 0.
	r addMorphBack: (self buttonName: '>>' action: #nextLayer).
	r addMorphBack: (self buttonName: '<<' action: #prevLayer).
	r addMorphBack: (self buttonName: 'shrink to changing pixels' action: #shrinkToChange).
	r addMorphBack: (self buttonName: 'extract' action: #extract).
	self addMorphBack: r.
