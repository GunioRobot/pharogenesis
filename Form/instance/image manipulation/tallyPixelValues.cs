tallyPixelValues
	"Return a Bitmap with tallies in it of the number of pixels in this Form
	that have each of the given values.  Note that several forms may be
	tallied into the same table by callingtPVInto: with the same table.
	Also bitmaps of depth 16 or 32 can be tallied into tables of size
	512, 4096 or 32768 by direct calls with a Bitmap of such size."
	| tallies pixPerWord |
	tallies _ Bitmap new: (1 bitShift: (self depth min: 9)).
	self tallyPixelValuesPrimitive: self boundingBox into: tallies.
	pixPerWord _ 32//depth.
	self width\\pixPerWord ~= 0 ifTrue:
		["Subtract bogus null-count due to word-boundary."
		tallies at: 1 put: (tallies at: 1) - (pixPerWord-(self width\\pixPerWord)*self height)].
	^ tallies