additionsToViewerCategoryTests
	"Answer viewer additions for the 'tests' category."

"Note:  Because of intractable performance problems in continuously evaluating isOverColor in a Viewer, the isOverColor entry is not given a readout"

	^#(
		#tests 
		(
			(slot isOverColor 'whether any part of the object is over the given color' Boolean	readOnly Player seesColor: unused unused)
			(slot isUnderMouse 'whether the object is under the current mouse position' Boolean readOnly	Player getIsUnderMouse unused unused)
			(slot colorSees	'whether the given color sees the given color' Boolean readOnly	Player color:sees:	unused	unused)
			(slot overlaps    'whether I overlap a given object' Boolean readOnly Player overlaps: unused unused)
			(slot overlapsAny    'whether I overlap a given object or one of its siblings or similar objects' Boolean readOnly Player overlapsAny: unused unused)
			(slot touchesA	'whether I overlap any  Sketch that is showing the same picture as a particular prototype.' Boolean readOnly Player touchesA:	unused	unused)
			(slot obtrudes 'whether the object sticks out over its container''s edge' Boolean readOnly Player getObtrudes unused unused)
		)
	)
