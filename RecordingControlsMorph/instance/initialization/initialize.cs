initialize

	| r |
	super initialize.
	borderWidth _ 2.
	orientation _ #vertical.
	recorder _ SoundRecorder new.
	self addButtonRows.

	r _ LayoutMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: self makeRecordMeter.
	self addMorphBack: r.
