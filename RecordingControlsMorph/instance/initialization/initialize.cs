initialize

	| r |
	super initialize.
	borderWidth _ 2.
	orientation _ #vertical.
	recorder _ SoundRecorder new.
	self addButtonRows.

	r _ AlignmentMorph newRow vResizing: #shrinkWrap.
	r addMorphBack: self makeRecordMeter.
	self addMorphBack: r.
	self extent: 10@10.  "make minimum size"
