addButtonRows
	"Spun off to allow subclasses to customize the buttons but still benefit from super intialize"

	| r |
	r _ LayoutMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: (self buttonName: 'Tile' action: #makeTile).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Trim' action: #trim).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Show' action: #show).
	self addMorphBack: r.

	r _ LayoutMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: (self buttonName: 'Record' action: #record).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Stop' action: #stop).
	r addMorphBack: (Morph new extent: 4@1; color: Color transparent).
	r addMorphBack: (self buttonName: 'Play' action: #playback).
	r addMorphBack: self makeStatusLight..
	self addMorphBack: r